# API de Clientes

Esta API de clientes proporciona endpoints para administrar información de clientes, como obtener la lista de clientes, buscar clientes por nombre, agregar nuevos clientes, actualizar información de clientes existentes y eliminar clientes.

## Tecnologías utilizadas

- ASP.NET Core
- Entity Framework Core
- AutoMapper

## Estructura del proyecto

El proyecto se divide en las siguientes partes:

- **Models**: Contiene las clases de modelo utilizadas para representar la información de los clientes y los DTO (Data Transfer Objects) utilizados para la transferencia de datos.
- **Repository**: Contiene la interfaz `IClientRepository` y la implementación `ClientRepository`, que proporcionan métodos para acceder y manipular los datos de los clientes en la base de datos.
- **Profiles**: Contiene el perfil `ClientProfile` utilizado por AutoMapper para mapear entre las entidades de cliente y los DTO de cliente.
- **Controllers**: Contiene el controlador `ClientController`, que define los endpoints de la API para gestionar los clientes.

## Configuración y ejecución

1. Clona este repositorio en tu máquina local.
2. Abre el proyecto en tu IDE preferido (por ejemplo, Visual Studio).
3. Configura la cadena de conexión a tu base de datos en el archivo `appsettings.json`.
4. Compila y ejecuta el proyecto.

## Endpoints de la API

A continuación se describen los endpoints disponibles en la API:

### Obtener lista de clientes

- Método: GET
- Ruta: /api/client
- Descripción: Retorna la lista de todos los clientes.
- Respuesta exitosa: 200 OK con la lista de clientes en formato JSON.
- Respuesta de error: 400 Bad Request si ocurre algún error.

### Obtener un cliente por ID

- Método: GET
- Ruta: /api/client/{id}
- Descripción: Retorna los detalles de un cliente específico según su ID.
- Respuesta exitosa: 200 OK con los detalles del cliente en formato JSON.
- Respuesta de error: 404 Not Found si no se encuentra el cliente o 400 Bad Request si ocurre algún error.

### Buscar clientes por nombre

- Método: GET
- Ruta: /api/client/search/{name}
- Descripción: Busca clientes que coincidan con el nombre especificado.
- Respuesta exitosa: 200 OK con la lista de clientes encontrados en formato JSON.
- Respuesta de error: 204 No Content si no se encuentran resultados o 400 Bad Request si ocurre algún error.

### Agregar un nuevo cliente

- Método: POST
- Ruta: /api/client
- Descripción: Agrega un nuevo cliente a la base de datos.
- Cuerpo de la solicitud: Objeto JSON con los datos del cliente.
- Respuesta exitosa: 201 Created con los detalles del cliente agregado en formato JSON.
- Respuesta de error: 400 Bad Request si ocurre algún error.

### Actualizar un cliente existente

- Método: PUT
- Ruta: /api/client/{id}
- Descripción: Actualiza la información de un cliente existente.
- Cuerpo de la solicitud: Objeto JSON con los datos actualizados del cliente.
- Respuesta exitosa: 204 No Content si la actualización se realiza correctamente.
- Respuesta de error: 400 Bad Request si ocurre algún error.

### Eliminar un cliente

- Método: DELETE
- Ruta: /api/client/{id}
- Descripción: Elimina un cliente de la base de datos.
- Respuesta exitosa: 204 No Content si la eliminación se realiza correctamente.
- Respuesta de error: 404 Not Found si no se encuentra el cliente o 400 Bad Request si ocurre algún error.

### Desactivar un cliente

- Método: DELETE
- Ruta: /api/client/disable/{id}
- Descripción: Desactiva un cliente estableciendo su estado a inactivo.
- Respuesta exitosa: 204 No Content si la desactivación se realiza correctamente.
- Respuesta de error: 404 Not Found si no se encuentra el cliente o 400 Bad Request si ocurre algún error.

## Contribuciones

Si deseas contribuir a este proyecto, puedes hacerlo mediante la apertura de issues o enviando pull requests.

## Licencia

Este proyecto está bajo la licencia [MIT](LICENSE).
