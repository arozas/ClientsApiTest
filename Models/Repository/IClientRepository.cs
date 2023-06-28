namespace ClientsApiTest.Models.Repository
{
    /// <summary>
    /// Interfaz que define los métodos para acceder y manipular la entidad Client en la base de datos.
    /// </summary>
    public interface IClientRepository
    {
        /// <summary>
        /// Obtiene una lista de todos los clientes.
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica y contiene la lista de clientes.</returns>
        Task<List<Client>> GetClientList();

        /// <summary>
        /// Obtiene un cliente por su identificador.
        /// </summary>
        /// <param name="id">El identificador del cliente.</param>
        /// <returns>Una tarea que representa la operación asincrónica y contiene el cliente encontrado.</returns>
        Task<Client> GetClient(int id);

        /// <summary>
        /// Elimina un cliente.
        /// </summary>
        /// <param name="client">El cliente a eliminar.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        Task DeleteClient(Client client);

        /// <summary>
        /// Agrega un nuevo cliente.
        /// </summary>
        /// <param name="client">El cliente a agregar.</param>
        /// <returns>Una tarea que representa la operación asincrónica y contiene el cliente agregado.</returns>
        Task<Client> AddClient(Client client);

        /// <summary>
        /// Actualiza un cliente existente.
        /// </summary>
        /// <param name="client">El cliente a actualizar.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        Task UpdateClient(Client client);

        /// <summary>
        /// Realiza una búsqueda de clientes por nombre.
        /// </summary>
        /// <param name="name">El nombre a buscar.</param>
        /// <returns>Una tarea que representa la operación asincrónica y contiene la lista de clientes encontrados.</returns>
        Task<IEnumerable<Client>> Search(string name);

        /// <summary>
        /// Deshabilita un cliente.
        /// </summary>
        /// <param name="client">El cliente a deshabilitar.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        Task DisableClient(Client client);
    }
}
