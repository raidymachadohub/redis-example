# Examplo Redis .NET Core 3.1

Redis é um armazenamento de estrutura de dados em memória, usado como um banco de dados em memória distribuído de chave-valor, cache e agente de mensagens, com durabilidade opcional

Neste exemplo estou adicionando uma lista de produtos em Cache usando Redis. Para que toda vez seja executado não precisa consultar no banco de dados. 

## Instalação

- Microsoft.EntityFrameworkCore
- SQLite
- Redis

```bash
>.NET
dotnet add package Microsoft.Extensions.Caching.StackExchangeRedis

>Docker
docker pull redis
docker run --name local-redis -p 6379:6379 -d redis
```