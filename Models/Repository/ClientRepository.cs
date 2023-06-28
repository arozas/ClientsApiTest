using Microsoft.EntityFrameworkCore;

namespace ClientsApiTest.Models.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly AplicationDataBaseContext _context;

        public ClientRepository(AplicationDataBaseContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> GetClientList()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetClient(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(client => client.Id == id && client.Active);
        }

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


        public async Task<Client> AddClient(Client client)
        {
            _context.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task UpdateClient(Client client)
        {
            var clientItem = await _context.Clients.FirstOrDefaultAsync(x => x.Id == client.Id);

            if (clientItem != null)
            {
                clientItem.Id = client.Id;
                clientItem.Name = client.Name;
                clientItem.LastName = client.LastName;
                clientItem.BirthDate = client.BirthDate;
                clientItem.Cuit = client.Cuit;
                clientItem.Adress = client.Adress;
                clientItem.MobilPhone = client.MobilPhone;
                clientItem.Email = client.Email;

                //_context.Update(client);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteClient(Client client)
        {
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }

        public async Task DisableClient(Client client)
        {
            var clientItem = await _context.Clients.FirstOrDefaultAsync(x => x.Id == client.Id);

            if (clientItem != null)
            {
                clientItem.Active = false;

                //_context.Update(client);
                await _context.SaveChangesAsync();
            }
        }
    }
}
