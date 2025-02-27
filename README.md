## Pré-requisitos
Antes de começar, certifique-se de ter os seguintes pré-requisitos instalados:

- [.NET SDK](https://dotnet.microsoft.com/download) (versão 8.0.0 ou superior)
- [Visual Studio](https://visualstudio.microsoft.com/) ou outra IDE de sua escolha

## Clone o repositório:
- git clone https://github.com/Joao-Pedro-Fernandes/Teste-TI-Vigna-Advocacia.git

## Para rodar a API
- Entre na pasta "Teste TI Vigna Advocacia"
- Abra um terminal nessa pasta
- Digite o comando "dotnet run" no terminal e execute
- Após o projeto ser executado, é só acessar o end point por meio da url "http://localhost:5150/GetDataPdf" 
- Usando o postman você conseguirá fazer a requisição enviando um arquivo pdf contendo um processo jurídico
- A chave do arquivo deve se chamar "file"
- Ou utilize o swagger na url "http://localhost:5150/swagger/index.html"
- Se quiser um método de explicação diferente, na pasta clonada do projeto, tem um arquivo pdf chamado "Utilização da API". 
Neste arquivo você encontrará um exemplo ilustrado de como utilizar a API. 

## Como é chamada à API LLM
- Com o texto extraído pelo código do end point "GetDataPdf", acontece uma chamada a uma service de nome "GroqService.cs" 
passando o texto do pdf como parâmetro.
- Então, na service, é feita uma chamada usando HttpClient à API do Groq
- Para chamar a API LLM Groq, eu criei uma key de autenticação no link "https://console.groq.com/keys", e essa key me dá acesso ao chat da
inteligencia artificial do Groq por meio de requisições Http, em que a key precisa ser passada no header da requisição (Bearer Token).
- Após isso, eu criei um prompt que trata os dados conforme foi pedido no teste
- No final a service devolve uma string contendo um Json com as partes envolvidas e o numero do processo

## Exemplo de uso
- No arquivo "Detalhes sobre o teste de TI.pdf" tem um exemplo com imagens da utilização da api
