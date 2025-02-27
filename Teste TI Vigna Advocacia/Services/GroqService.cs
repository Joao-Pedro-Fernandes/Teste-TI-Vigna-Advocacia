using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Teste_TI_Vigna_Advocacia.Services
{
    public class GroqService
    {
        private readonly HttpClient _httpClient;
        private const string UrlGroq = "https://api.groq.com/openai/v1/chat/completions";
        private const string GroqApiKey = "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";

        public GroqService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> ResponseGroqPdfAnalyze(string text)
        {
            var requestBody = new
            {
                model = "llama-3.3-70b-versatile",
                messages = new[]
                {
                    new { role = "user", content = "Estou te enviando em formato de texto um processo jurídico" +
                    " que antes estava em formato de pdf." +
                    " Você deve fazer a extração do número do processo e das partes envolvidas." +
                    " Quero que na sua resposta seja em formato de json, da seguinte forma (exemplo):" +
                    " { numero_processo: NUMERO_DO_PROCESSO_AQUI, partes: [João da Silva (réu), Banco XYZ (Autor), José (Advogado)]}." +
                    " Sua resposta deve se limitar somente a este json." +
                    $" quero que extraia do seguinte texto: {text}" }
                }
            };

            var jsonRequest = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {GroqApiKey}");

            var response = await _httpClient.PostAsync(UrlGroq, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Erro na API Groq {response.StatusCode}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;
        }


        public string ExtractJson(string json)
        {
            try
            {
                using var document = JsonDocument.Parse(json);
                var root = document.RootElement;

                string? jsonContent = root
                    .GetProperty("choices")[0]
                    .GetProperty("message")
                    .GetProperty("content")
                    .GetString();

                if (string.IsNullOrEmpty(jsonContent))
                    throw new Exception("Erro ao reconhecer o json");

                using var jsonDocument = JsonDocument.Parse(jsonContent);
                jsonDocument.RootElement.Clone();

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };

                return JsonSerializer.Serialize(jsonDocument, options);
            }
            catch (Exception ex)
            {
                return $"Erro ao processar a resposta da API {ex.Message}";
            }
        }

    }
}
