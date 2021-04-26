# DesafioFULL
App desenvolvido com Angular e Razor, DevExtreme, C#, SQL e EFCore para cadastro e listagem de dívidas.

## Instruções de instalação
1. Clone o repositório
2. No terminal cmd rode `dotnet restore` na pasta raiz.
3. No terminal cmd rode `npm install` na pasta <b>src\AppAngularClient</b>.


- O arquivo `divida.service.ts`(client/src/app/services) contém a string <b>url</b>, utilizada para consultar o backend. Se o backend for executado em outro lugar que não https://localhost:5001, essa string deve ser alterada de acordo.
```Client
url: string = 'https://localhost:9000'; Razor
url: string = 'https://localhost:4200'; Angular
````


## Instruções de execução
1. Use o terminal cmd para rodar `dotnet run` na pasta raiz.
2. Abra um novo terminal e, na pasta <b>src\AppAngularClient</b>, rode `ng serve`.
