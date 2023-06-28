namespace ClientsApiTest.Models.Repository
{
    public interface IClientRepository
    {
        Task<List<Client>> GetClientList();
        Task<Client> GetClient(int id);
        Task DeleteClient(Client client);
        Task<Client> AddClient(Client client);
        Task UpdateClient(Client client);
        Task<IEnumerable<Client>> Search(string name);
        Task DisableClient(Client client);
    }
}
