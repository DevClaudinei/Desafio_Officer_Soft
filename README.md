<h1 align="center">Desafio_Officer_Soft</h1>

## Descrição do desafio

<p align="center">Analisar e desenvolver um sistema de cadastro de pessoas</p>
  
### Requisitos funcionais:

- [x] Tela de login com usuário e senha para acessar a aplicação, validando informações no banco de dados;
- [x] Cadastro de pessoa, com possibilidade de pesquisar, editar, cadastrar um novo e excluir.

### Requisitos não funcionais:

- [x] Banco de dados deve ter no mínimo 2 tabelas (usario e pessoa);
- [x] Senha dos usuário deve estar criptografadas no banco de dados (qualquer padrão). Ex.: Hash, MD5;
- [x] Ter um usuário padrão (admin);
- [x] Não permitir 2 dois cadastros de pessoa com o mesmo CPF;
- [x] Campos de CEP e CPF devem ser formatados com máscara (Ex. do CPF: 111.111.111-11).

## Documentação técnica do desafio

### Escolha da tecnologia e do tipo de projeto a ser utilizado
Para atender o item 1 dos requisitos funcionais poderia criar um projeto API Web do ASP.NET Core (o qual tenho bastante familiaridade) ou Aplicativo Web do ASP.NET Core (Model-View-Controller). Decidi me arriscar na segunda opção para tornar as coisas mais dinamicas e visuais pensando na apresentação das funcionalidades exigidas por este desafio.

## Pré-requisitos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
[Git](https://git-scm.com), [.NET](https://dotnet.microsoft.com/en-us/download). 
Além disto é bom ter um editor para trabalhar com o código como [Visual Studio Code ou Visual Studio](https://code.visualstudio.com/download) 

## 🎲 Rodando o Back End (servidor)

```bash
# Clone este repositório
$ git clone https://github.com/DevClaudinei/Desafio_Officer_Soft.git

# Acesse a pasta do projeto no terminal/cmd
$ cd Desafio_Officer_Soft\src\CadastroPessoa

# Execute a aplicação
$ Executar o comando dotnet run 

# O servidor inciará na porta:7167 
- Utilizando a URL <https://localhost:7167>
```
## Tela inicial:
![image](https://user-images.githubusercontent.com/103595662/229291345-339367c1-737c-4c32-b789-db2def040e40.png)

### Login 
- É utilizado para utilizar as funcionalidades do sistema. Para isso será necessário informar email e senha.

- Usuário padrão cadastrado utiliza o email: admin@teste.com e senha: Admin@1234

### Register
- É utilizado para cadastrar um novo usuário que terá acesso as funcionalidade do sistema, uma vez que estiver cadastrado no banco de dados.

### Cadastros
Nesta pagina teremos as possibilidades:

- Observar a lista de todas as pessoas cadastradas (Cadastro);
- Realizar o cadastro de uma nova pessoa (Cadastrar Pessoa);
- Atualizar o cadastro de uma pessoa (Edit);
- Excluir o cadastro de uma pessoa (Delete);
- Buscar uma pessoa pelo nome (Cadastro);
- Buscar uma pessoa pelo CPF (Cadastro);
- Buscar uma pessoa pelo Id (Details);

### Tela de Create
![image](https://user-images.githubusercontent.com/103595662/229291412-3c4bd5d2-8fb4-4b43-bb00-121ad6b3f1ca.png)

### Tela de Edit
![image](https://user-images.githubusercontent.com/103595662/229291514-6b56dbea-f407-43bc-a7e9-3b7d8f24b0f8.png)

### Tela de Delete
![image](https://user-images.githubusercontent.com/103595662/229291549-d291bedc-ea46-4be3-80ab-d1312cfb992a.png)

### Tela Cadastro
![image](https://user-images.githubusercontent.com/103595662/229291724-7f272d1e-63a9-4783-bc58-0de35e84c0bf.png)


## 🛠 Tecnologias

As seguintes ferramentas foram usadas na construção do projeto:

- [.NET](https://dotnet.microsoft.com/en-us/)
- [ASP.NET Core MVC](https://learn.microsoft.com/pt-br/aspnet/core/mvc/overview?view=aspnetcore-6.0)
- [Identity](https://learn.microsoft.com/pt-br/aspnet/core/security/authentication/identity?view=aspnetcore-6.0&tabs=visual-studio)
- [SQLite](https://sqlite.org/download.html)
- [AutoMapper](https://automapper.org/)
- [FluentValidation](https://docs.fluentvalidation.net/en/latest/)
- [UnitOfWork](https://www.nuget.org/packages/EntityFrameworkCore.Data.UnitOfWork)
- [EntityFramework](https://learn.microsoft.com/pt-br/ef/)
- [XUnit](https://xunit.net/)
- [Moq](https://documentation.help/Moq/)
- [Bogus](https://github.com/bchavez/Bogus)
- [Fluent Assertions](https://fluentassertions.com/)

## Licença

Licensed under the [MIT license](LICENSE).

## Autor

<b>Claudinei Santos</b>

Encontrei muitas dificuldades por optar por utilizar o ASP.NET Core MVC, mas com um pouco de estudo e um pouco de resiliência consegui deixar o projeto pronto. Apesar de criar paginas simples e não ter um certo capricho, acredito que consegui tirar diversos aprendizados. 
Ter construido o projeto dessa forma me fez ter um pouco mais de curiosidade para melhorar as minhas habilidades utilizando o padrão Model-View-Controller.

[![Linkedin Badge](https://img.shields.io/badge/-Claudinei-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/claudinei-santos-ti/)](https://www.linkedin.com/in/claudinei-santos-ti/)
[![Gmail Badge](https://img.shields.io/badge/-santos.devclaudinei@gmail.com-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:santos.devclaudinei@gmail.com)](mailto:claudinei.santos@warren.com.br)
