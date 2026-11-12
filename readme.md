
Instalar paquetes NuGet.

Portafolio.Infrastructure

´´´
dotnet add Portafolio.Infrastructure package Microsoft.EntityFrameworkCore
dotnet add Portafolio.Infrastructure package Microsoft.EntityFrameworkCore.Design
dotnet add Portafolio.Infrastructure package Npgsql.EntityFrameworkCore.PostgreSQL
´´´

Portafolio.Api

´´´
dotnet add Portafolio.Api package Microsoft.EntityFrameworkCore.Design
dotnet add Portafolio.Api package Swashbuckle.AspNetCore
´´´

Habilitar:
<GenerateDocumentationFile>true</GenerateDocumentationFile>


Herramienta Scaffold

´´´
dotnet tool install --global dotnet-ef --version 8.0.27
´´´

Ejecutar Scaffold

Luego agregar cadena de conexión en: Portafolio.WebApi/appsettings.json

´´´
dotnet ef dbcontext scaffold "Host=localhost;Port=5432;Database=portafolio;Username=usr_portafolio;Password=secret" Npgsql.EntityFrameworkCore.PostgreSQL --project Portafolio.Infrastructure --startup-project Portafolio.WebApi --context PortafolioDbContext --context-dir Persistence/Contexts --output-dir Persistence/Entities --no-onconfiguring --force
´´´

Portafolio.Infrastructure

´´´
dotnet add Portafolio.Infrastructure package AutoMapper.Extensions.Microsoft.DependencyInjection
´´´