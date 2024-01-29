# CRUD API Dapper SQLite

Este é um projeto simples que demonstra como criar uma API CRUD (Create, Read, Update, Delete) em .NET utilizando Dapper e SQLite.

## Funcionalidades

- Listar todos os produtos
- Buscar um produto pelo ID
- Adicionar um novo produto
- Atualizar um produto existente
- Excluir um produto

## Tecnologias Utilizadas

- .NET 8
- Dapper 2.1
- SQLite.Core 1.0

## Pré-requisitos

- .NET 8 SDK
- SQLite

## Configuração do Banco de Dados

O banco de dados SQLite será criado automaticamente quando o aplicativo for iniciado pela primeira vez. Certifique-se de que o arquivo de banco de dados `database.db` seja criado no diretório do aplicativo.

## Instalação

1. Clone o repositório:
git clone https://github.com/seu-usuario/CRUD_DapperSqlite.git

2. Navegue até o diretório do projeto:

3. Execute o aplicativo:

Documentação da API
A API é documentada utilizando Swagger para gerar automaticamente uma documentação interativa. Os endpoints podem ser visualizados e testados navegando até https://localhost:(porta)/swagger após iniciar o aplicativo.
