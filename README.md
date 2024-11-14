# Alb.Function.Http

Estructura básica de un proyecto de tipo Azure Function con Entity Framework Core para gestión de migraciones con PostgreSql como proveedor de base de datos.

## Herramientas y Tecnologías
- .Net v8
- Azure Function v4, HttpTrigger
- Entity Framework Core
- PostgreSql
- Automapper

La definición del proyecto esta basada en arquitectura limpia definiendo las siguientes capas, tomar en cuenta que las capas dependeran de las necesidades del proyecto y el enfoque del desarrollador:

## Capa de Presentación
Proyecto de tipo Azure Function con desencadenador HTTP, se comportara como una API serverless.

- Dependencias:
    - Capa de Aplicación
    - Capa de Infraestructura

## Capa de Aplicación
Proyecto de tipo librería de clases .net 8 definida para la interacción entre la capa de presentación y la capa de dominio, encapsula los casos de uso que seran manejados por la API.

- Dependencias:
    - Capa de Contratos
    - Capa de Dominio

- Paquetes:
    - AutoMapper.Extensions.Microsoft.DependencyInjection

## Capa de Contratos
Proyecto de tipo librería de clases .net standart 2.1 para definir interfaces de los servicios de aplicación y DTOs implementados en la capa de aplicación.

- Dependencias:
    - Capa de Dominio Compartido

## Capa de Dominio
Proyecto de tipo librería de clases .net 8 definida para la definición del nucleo del proyecto, contiene reglas de negocio y el control sobre las operaciones a la base de datos.

- Dependencias:
    - Capa de Dominio Compartido

## Capa de Dominio Compartido
Proyecto de tipo librería de clases .net standart 2.1 para definir constantes, enumeradores, catálogos, diccionarios... utilizados en capas superiores.

## Capa de Infraestructura
Proyecto de tipo librería de clases .net 8 definida para implementación de herramientas y/o servicios externos como interacción a bases de datos, APIs de terceros, librerías, ... 

- Dependencias:
    - Capa de Dominio

- Paquetes:
    - Npgsql.EntityFrameworkCore.PostgreSQL
    - Microsoft.EntityFrameworkCore.Design
    - Microsoft.EntityFrameworkCore.Tools


## Migraciones
Entity Framework Core utiliza **migrations** para gestionar el esquema de base de datos a lo largo del tiempo, se debera tomar en cuenta que la arquitectura de Azure Functions
requiere consideraciones adicionales para ejecutar migraciones, por ejemplo proveer el DbContext en tiempo de diseño a diferencia de aplicaciones de ASP.NET Core que que proveen el contexto en 
tiempo de ejecución, para solucionar esto consulte IDesignTimeDbContextFactory y defina variables de entorno en su sistema para proporcionar la cadena de conexión ya que el contenedor de 
dependencias de su Azure Function no proveera la cadena en tiempo de diseño.

Comandos basicos para la creación y ejecución de migraciones

- Crear migración: `dotnet ef migrations add <name_migration> -- project Alb.Function.Infraestructure.csproj -c AppFunctionDbContext --verbose`
- Aplicar migración: `dotnet ef database update --project Alb.Function.Infraestructure.csproj -c AppFunctionDbContext --verbose`

Los comandos deberan ser ejecutados desde el directorio raíz del proyecto que contiene el Dbcontext.

... eso es todo por ahora. 
:D
