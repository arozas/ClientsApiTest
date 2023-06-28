using AutoMapper;
using ClientsApiTest.Models.DTO;

namespace ClientsApiTest.Models.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDTO>();
            CreateMap<ClientDTO, Client>();
        }
    }
}
