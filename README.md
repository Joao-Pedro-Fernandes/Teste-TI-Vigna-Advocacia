## Pré-requisitos
Antes de começar, certifique-se de ter os seguintes pré-requisitos instalados:

- [.NET SDK](https://dotnet.microsoft.com/download) (versão 8.0.24 ou superior)
- [Visual Studio](https://visualstudio.microsoft.com/) ou outra IDE de sua escolha

## Clone o repositório:
- git clone https://github.com/Joao-Pedro-Fernandes/Teste-TI-Vigna-Advocacia.git

## Para Rodar a API
- Com o Visual Studio 2022 instalado, basta abrir a pasta "Teste-TI-Vigna-Advocacia" e executar o arquivo "Teste TI Vigna Advocacia.sln"
- Dentro do Visual Studio, basta executar o projeto (teclando F5) e a api será executada

## Utilização da API
- Para consumir a API, abra o seu navegador de internet e digite o link https://localhost:7041/swagger/index.html
    - Se for utilizar outra ferramenta para testar api, o end point (post) está no link https://localhost:7041/GetDataPdf
        - O arquivo pdf precisa ser enviado com a key "file"
- Na página do swagger, abra o end point "/GetDataPdf"
- Clique em "Try it out"
- Escolha um arquivo que contenha um processo jurídico não muito grande, pois a API que analisa tem limitação da quantidade de texto 
(recomendo no máximo 8 páginas)
- Ao clicar em "execute", a API irá processar o PDF e retornará um Json com o número do processo e as partes envolvidas

## Como é chamada à API LLM
- Para chamar a API LLM Groq, eu criei uma key de autenticação no link "https://console.groq.com/keys", e essa key me dá acesso ao chat da
inteligencia artificial do Groq por meio de requisições Http, em que a key precisa ser passada no header da requisição (Bearer Token).
- Após isso, eu precisei apenas encontrar um jeito de obter o texto do pdf que foi enviado para o end point e enviá-lo no body da requisição,
juntamente com um prompt que trata os dados conforme foi pedido no teste.

## Exemplo de uso
- No arquivo "Detalhes sobre o teste de TI.pdf" tem um exemplo com imagens da utilização da api
