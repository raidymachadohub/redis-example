# Examplo Redis .NET Core 3.1

Redis � um armazenamento de estrutura de dados em mem�ria, usado como um banco de dados em mem�ria distribu�do de chave-valor, cache e agente de mensagens, com durabilidade opcional

Neste exemplo estou adicionando uma lista de produtos em Cache usando Redis. Para que toda vez seja executado n�o precisa consultar no banco de dados. 

## Instala��o

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