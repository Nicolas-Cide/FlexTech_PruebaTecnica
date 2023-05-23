# Banco API

Esta API permite consultar los movimientos de crédito del BCRA para una cuenta específica.

## Características

- Consulta los movimientos de crédito del BCRA para una cuenta determinada.
- Implementa una arquitectura basada en servicios y una inyección de dependencias para mantener un código modular y de fácil mantenimiento.
- Utiliza ASP.NET Core 6.0 y SQL Server para el backend.
- Admite el manejo de errores y devuelve respuestas adecuadas en caso de excepciones.

## Configuración

Antes de ejecutar la API, asegúrate de configurar la cadena de conexión a la base de datos en el archivo `appsettings.json`. Puedes encontrar la propiedad `ConnectionString` dentro de la sección `DatabaseSettings`.

## Endpoints

### Obtener movimientos de crédito

Este endpoint permite obtener los movimientos de crédito del BCRA para una cuenta específica.

- Método: GET
- Ruta: /bcra/movimientos/{cuenta}/credito
- Parámetros de ruta:
  - `{cuenta}`: Número de cuenta para el cual se desean obtener los movimientos de crédito.

Ejemplo de solicitud:
- GET `/bcra/movimientos/198/credito`

## Requisitos del sistema

Antes de ejecutar la API, asegúrate de cumplir con los siguientes requisitos del sistema:

- .NET Core 6.0 SDK o superior instalado en tu máquina.
- SQL Server para la base de datos.

## Configuración del entorno

Sigue estos pasos para configurar el entorno de desarrollo:

1. Clona este repositorio en tu máquina local.
2. Configura la cadena de conexión a la base de datos en el archivo `appsettings.json`.
3. Abre el proyecto en tu entorno de desarrollo.
4. Compila y ejecuta la aplicación.

## Creación de tabla

Copia este código para crear la tabla movimientosBcra en el caso que lo necesites:

```sql
CREATE TABLE [dbo].[movimientosBcra](
    [operatoria] [varchar](10) NULL,
    [transaccion] [varchar](10) NULL,
    [entidadDeudora] [varchar](10) NULL,
    [cuentaDeudora] [varchar](10) NULL,
    [entidadAcreedora] [varchar](10) NULL,
    [cuentaAcreedora] [varchar](10) NULL,
    [importe] [decimal](18, 2) NULL,
    [instruccionDePago] [varchar](50) NULL,
    [fechaProcesado] [datetime] NULL,
    [numeroInterno] [varchar](50) NULL
);

