
# Futebol Clube

Aplicação Web utilizando .Net Framework 4.7.2 com WebForms e Banco de dados SQL em arquivo .mdf localizado na pasta App_Data. Consiste em uma tela com listagem, cadastro e edição de ateltas bem como calculo de IMC e classificação baseada neste calculo.

- Net Framework 4.7.2
- Nunit


## Rodando localmente

1. Clone o projeto

```bash
  git clone https://github.com/WilliamAbelo/FCWebApplication.git
```

2. Abra a aplicação com o Visual Studio

![open project](https://learn.microsoft.com/fr-fr/visualstudio/ide/media/vs-2019/open-local-project-from-cloned-repo.png?view=vs-2017&viewFallbackFrom=vs-2022)

3. Apos aberto o projeto, rode com o iis express

![run project](https://user-images.githubusercontent.com/1798510/68414453-81092500-0190-11ea-8564-918bd89f0da5.png)

4. Foi utilizado o Banco de Dados SQL Server nessa aplicação e o arquivo .mdf encontrasse na pasta App_Data, as configurações para o acesso ao banco estão no arquivo ***Web.config dentro do nó <connectionStrings>***

> [!WARNING]
> Certifique-se que estaja na pagina index.aspx (https://localhost:44309/index.aspx) apos rodar o projeto.

## Funcionalidades

- Listagem de Atletas
- Adição de Atletas
- Edição de Atletas
- Exclusão de Atletas

- Filtro na Listagem de Atletas, por: Numero de camisa, Apelido e Classificação do IMC


## Rodando os testes

Para rodar os testes certifiquese que a dependencia Nunit esteja intalada e utilize a ferramenta de testes do Visual studio

![run test](https://learn.microsoft.com/pt-br/visualstudio/test/media/vs-2022/test-explorer-groupby-state-17-0.png?view=vs-2017&viewFallbackFrom=vs-2022)



## Autores

- [@WilliamAbelo](https://github.com/WilliamAbelo)

