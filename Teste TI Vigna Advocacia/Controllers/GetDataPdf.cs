using System.Text;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using Microsoft.AspNetCore.Mvc;
using Teste_TI_Vigna_Advocacia.Services;

namespace Teste_TI_Vigna_Advocacia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetDataPdf : ControllerBase
    {
        private readonly GroqService _groqService;

        public GetDataPdf(GroqService groqService)
        {
            _groqService = groqService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadPdf(IFormFile file)
        {
            if (file == null)
            {
                return BadRequest("Não foi possível processar o seu arquivo.");
            }

            try
            {
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                using var pdfReader = new PdfReader(memoryStream);
                using var pdfDocument = new PdfDocument(pdfReader);

                StringBuilder text = new StringBuilder();
                
                for (int i = 1; i <= pdfDocument.GetNumberOfPages(); i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(i)));
                }

                var response = await _groqService.ResponseGroqPdfAnalyze(text.ToString());              

                return Ok(_groqService.ExtractJson(response));
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro: {ex.Message}");
            }

        }

    }
}
