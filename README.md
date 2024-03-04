# PruebaIngresoBackend Jose Brayan Ocampo Castaño

## Arquityectura del proyecto

- Se utiliza un arquitectura Multicapa (3 layer architecture)

> Bussines Logic Layer

> Data Access Layer

> Web API Layer

## Tecnolgias utilizadas


- ASP .NET core 8.0, SQL Server, SQL Server Management Studio 19, Visual Studio 2022

> ![image](https://github.com/ocarionza/PruebaIngresoBackendBrayanOcampo/assets/45015355/f15e6a87-277f-43e0-b56d-31a71e528d60)


## Observaciones

- Se observa que ninguno de los endpoints mencionados en la prueba funcionan por lo que en el codigo se tienen algunas lineas comentadas, en caso de poder acceder a los endpoints mencionados, solo debe descomentar dichas lineas: 

### Rutas únicas
> https://recruiting-api.newshore.es/api/flights/0

### Rutas múltiples
> https://recruiting-api.newshore.es/api/flights/1

### Rutas múltiples y de retorno
> https://recruiting-api.newshore.es/api/flights/2


- A continuacion se muestra donde se pueden encontrar las lineas de codigo mencionadas, por motivo de pruebas se utiliza una variable de tipo string con un json sencillo:

> PruebaIngresoBackend\Business\Services\Journey\JourneyService.cs

> ![image](https://github.com/ocarionza/PruebaIngresoBackendBrayanOcampo/assets/45015355/bc1b43cf-3617-4786-b199-2af720c11e8b)


## Configuración del entorno
- Dirigase a la ruta (PruebaIngresoBackend\PruebaIngresoBackend\appsettings.json)

- Cambie la cadena de conexion en el punto donde señala la siguiente imagen: 

> ![image](https://github.com/ocarionza/PruebaIngresoBackendBrayanOcampo/assets/45015355/26b05faa-9b62-4c3f-991c-c4d3cbca5cea)

- Abra la consola del administrador de paquetes: 

> ![image](https://github.com/ocarionza/PruebaIngresoBackendBrayanOcampo/assets/45015355/c4586b6f-f383-412a-8128-82b3c6152295)

- Seleccione como proyecto preterminado DataAccess

> ![image](https://github.com/ocarionza/PruebaIngresoBackendBrayanOcampo/assets/45015355/8094dd6e-9b8d-4277-b7c0-a2b4e91925a9)

- Ejecute el siguiente comando en consola para importar las migraciones: 

> Update-database

- Se deja un query (SQL) sencillo en la carpeta del proyecto en caso de ser necesario el cual puede importar en SQL Server Management Studio 19

> db_query.sql

- Se debe inciar el proyecto desde la capa de API, y puede utilizar Swagger para realizar pruebas 

> ![image](https://github.com/ocarionza/PruebaIngresoBackendBrayanOcampo/assets/45015355/b3dea502-8eca-4a73-bce6-fa6242d1abc1)


