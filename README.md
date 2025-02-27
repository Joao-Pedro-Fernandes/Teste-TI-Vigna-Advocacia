## Pré-requisitos
Antes de começar, certifique-se de ter os seguintes pré-requisitos instalados:

- [.NET SDK](https://dotnet.microsoft.com/download) (versão 8.0.24 ou superior)
- [Visual Studio](https://visualstudio.microsoft.com/) ou outra IDE de sua escolha

## Clone o repositório:
- git clone https://github.com/Joao-Pedro-Fernandes/Teste-TI-Vigna-Advocacia.git

## Para rodar a API
- Na pasta clonada do projeto, tem um arquivo pdf chamado "Utilização da API". Neste arquivo você encontrará um exemplo de como utilizar a API. 

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
