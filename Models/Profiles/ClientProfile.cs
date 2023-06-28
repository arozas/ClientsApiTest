using AutoMapper;
using ClientsApiTest.Models.DTO;

namespace ClientsApiTest.Models.Profiles
{
    /// <summary>
    /// Perfil de AutoMapper para mapear entre la entidad Client y el DTO ClientDTO.
    /// </summary>
    public class ClientProfile : Profile
    {
        /// <summary>
        /// Constructor de la clase ClientProfile.
        /// </summary>
        public ClientProfile()
        {
            // Define los mapeos entre la entidad Client y el DTO ClientDTO.
            CreateMap<Client, ClientDTO>();
            CreateMap<ClientDTO, Client>();
        }
    }
}
