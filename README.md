# Sales Web Mvc

> Status do Projeto: :heavy_check_mark:

## Tópicos

- [Descrção do projeto](#descrição-do-projeto)
- [Tecnologias usadas](#tecnologias-usadas)
- [Funcionalidades](#funcionalidades)
- [Pré-requisitos](#pré-requisitos)
- [Como rodar a aplicação](#como-rodar-a-aplicação)

## Descrição do projeto

Projeto criado no curso C# Completo Programação Orientada a Objetos + Projetos do professor Nélio Alves. Este projeto tem o objetivo de introduzir o aluno ao desenvolvimento web com Asp.Net Core MVC, a partir desse projeto o aluno terá noções básicas de desenvolvimento web com a linguagem C# e será capaz de ter uma base para poder prosseguir estudando as especificidades que desejar.

Esse projeto foi arquitetado com a arquitetura MVC (Model View Controller), permitindo a separação clara de responsabilidades, que permite um melhor entendimento sobre o funcionamento do software, que servirá de base para estudos mais aprofundados em outros tópicos no futuro.

## Tecnologias usadas

- Linguagem de programação C#;
- Framework Asp.Net Core 8;
- Banco de dados PostgreSQL executado em docker;
- Entity Framework como ORM;

## Funcionalidades

- Criação de vendedores e departamentos;
- Relacionar vendedores com vendas;
- Listagens simples e agrupada de vendas;

## Pré-requisitos

- [.Net 8](https://dotnet.microsoft.com/pt-br/download)
- [Docker](https://www.docker.com/)

## Como rodar a aplicação

Execute o seguinte comando para clonar o projeto:

```bash
git clone https://github.com/AnndreJunior/SalesWebMvc.git
```

Após o projeto ser clonado, acesse diretório diretório do projeto e execute o seguinte comando para restaurar as dependências:

```bash
dotnet restore
```

Antes de executar a aplicação, será necessário subir um container com o banco de dados:

```bash
docker run --name sales-web-db -e POSTGRES_DB=sales -e POSTGRES_PASSWORD=admin -p 5432:5432 -d postgres
```

Agora será necessário aplicar a migração no banco, para isso será necessário ter a ferramenta dotnet ef, para mais informações sobre a ferramenta [acesse aqui](https://learn.microsoft.com/pt-br/ef/core/cli/dotnet). Para aplicar a migration execute o seguinte comando:

```bash
dotnet ef database update --project SalesWebMvc
```

Por fim, execute o projeto e acesse o endereço http://localhost:5085.

```bash
dotnet run --project SalesWebMvc
```
