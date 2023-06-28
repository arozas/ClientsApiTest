using Microsoft.EntityFrameworkCore;

namespace ClientsApiTest.Models.Repository
{
    /// <summary>
    /// Implementación de la interfaz IClientRepository para acceder y manipular la entidad Client en la base de datos.
    /// </summary>
    public class ClientRepository : IClientRepository
    {
        private readonly AplicationDataBaseContext _context;

        /// <summary>
        /// Constructor de la clase ClientRepository.
        /// </summary>
        /// <param name="context">El contexto de la base de datos.</param>
        public ClientRepository(AplicationDataBaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene una lista de todos los clientes.
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica y contiene la lista de clientes.</returns>
        public async Task<List<Client>> GetClientList()
        {
            return await _context.Clients.ToListAsync();
        }

        /// <summary>
        /// Obtiene un cliente por su identificador.
        /// </summary>
        /// <param name="id">El identificador del cliente.</param>
        /// <returns>Una tarea que representa la operación asincrónica y contiene el cliente encontrado.</returns>
        public async Task<Client> GetClient(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(client => client.Id == id && client.Active);
        }

        /// <summary>
        /// Realiza una búsqueda de clientes por nombre o apellido.
        /// </summary>
        /// <param name="name">El nombre a buscar.</param>
        /// <returns>Una tarea que representa la operación asincrónica y contiene la lista de clientes encontrados.</returns>
        public async Task<IEnumerable<Client>> Search(string name)
        {
            IQueryable<Client> query = _context.Clients;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.Name.Contains(name)
                            || e.LastName.Contains(name));
            }

            return await query.ToListAsync();
        }

        /// <summary>
        /// Agrega un nuevo cliente.
        /// </summary>
        /// <param name="client">El cliente a agregar.</param>
        /// <returns>Una tarea que representa la operación asincrónica y contiene el cliente agregado.</returns>
        public async Task<Client> AddClient(Client client)
        {
            _context.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        /// <summary>
        /// Actualiza un cliente existente.
        /// </summary>
        /// <param name="client">El cliente a actualizar.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        public async Task UpdateClient(Client client)
        {
            var clientItem = await _context.Clients.FirstOrDefaultAsync(x => x.Id == client.Id);

            if (clientItem != null)
            {
                clientItem.Name = client.Name;
                clientItem.LastName = client.LastName;
                clientItem.BirthDate = client.BirthDate;
                clientItem.Cuit = client.Cuit;
                clientItem.Adress = client.Adress;
                clientItem.MobilPhone = client.MobilPhone;
                clientItem.Email = client.Email;

                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Elimina un cliente.
        /// </summary>
        /// <param name="client">El cliente a eliminar.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        public async Task DeleteClient(Client client)
        {
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deshabilita un cliente.
        /// </summary>
        /// <param name="client">El cliente a deshabilitar.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        public async Task DisableClient(Client client)
        {
            var clientItem = await _context.Clients.FirstOrDefaultAsync(x => x.Id == client.Id);

            if (clientItem != null)
            {
                clientItem.Active = false;

                await _context.SaveChangesAsync();
            }
        }
    }
}
