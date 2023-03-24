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
![image](https://user-images.githubusercontent.com/103595662/227285631-ef78ca24-476b-4180-9db8-7e383d99dd3d.png)

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
![image](https://user-images.githubusercontent.com/103595662/227292912-c3f8e7e0-8ae5-4e44-99cc-c1161fdd7a3c.png)

### Tela de Edit
![image](https://user-images.githubusercontent.com/103595662/227295630-0e36727c-446d-4979-87a2-4a274a345645.png)

### Tela de Delete
![image](https://user-images.githubusercontent.com/103595662/227295839-f382825d-4412-4e22-b574-5074781be778.png)

### Tela Cadastro
![image](https://user-images.githubusercontent.com/103595662/227296379-4a496f34-7a23-4ba7-847b-111ef7ffa451.png)


## 🛠 Tecnologias

As seguintes ferramentas foram usadas na construção do projeto:

- [.NET](https://dotnet.microsoft.com/en-us/)
- [ASP.NET Core MVC](https://learn.microsoft.com/pt-br/aspnet/core/mvc/overview?view=aspnetcore-6.0)
- [Identity](https://learn.microsoft.com/pt-br/aspnet/core/security/authentication/identity?view=aspnetcore-6.0&tabs=visual-studio)
- [SQLite](https://sqlite.org/download.html)
- [AutoMapper](https://automapper.org/)
- [FluentValidation](https://docs.fluentvalidation.net/en/latest/)

## Licença

Licensed under the [MIT license](LICENSE).

## Autor

<b>Claudinei Santos</b>

Encontrei muitas dificuldades por optar por utilizar o ASP.NET Core MVC, mas com um pouco de estudo e um pouco de resiliência consegui deixar o projeto pronto. Apesar de criar paginas simples e não ter um certo capricho, acredito que consegui tirar diversos aprendizados. 
Ter construido o projeto dessa forma me fez ter um pouco mais de curiosidade para melhorar as minhas habilidades utilizando o padrão Model-View-Controller.

[![Linkedin Badge](https://img.shields.io/badge/-Claudinei-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/claudinei-santos-ti/)](https://www.linkedin.com/in/claudinei-santos-ti/)
[![Gmail Badge](https://img.shields.io/badge/-santos.devclaudinei@gmail.com-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:santos.devclaudinei@gmail.com)](mailto:claudinei.santos@warren.com.br)
