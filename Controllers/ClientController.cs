using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ClientsApiTest.Models.DTO;
using ClientsApiTest.Models.Repository;
using System.ComponentModel.DataAnnotations;
using ClientsApiTest.Models;

namespace ClientsApiTest.Controllers
{
    /// <summary>
    /// Controlador para la gestión de clientes.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;

        public ClientController(IMapper mapper, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var clientList = await _clientRepository.GetClientList();

                var clientListDto = _mapper.Map<IEnumerable<ClientDTO>>(clientList);

                return Ok(clientListDto);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var client = await _clientRepository.GetClient(id);

                if (client == null)
                {
                    return NotFound();
                }

                var ClientDto = _mapper.Map<ClientDTO>(client);

                return Ok(ClientDto);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [Route("[action]/{name}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> Search([RegularExpression(@"[a-zA-Z]+$", ErrorMessage = "Search parameter is incorrect.")]string name)
        {
            try
            {
                var searchResult = await _clientRepository.Search(name);

                if (searchResult.Any())
                {
                    var searchResultDto = _mapper.Map<IEnumerable<ClientDTO>>(searchResult);
                    return Ok(searchResultDto);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClientDTO clientDto)
        {
            try
            {
                var client = _mapper.Map<Client>(clientDto);

                client.RegistryDate = DateTime.Now;
                client.Active = true;

                client = await _clientRepository.AddClient(client);

                var clientDtoAux = _mapper.Map<ClientDTO>(client);

                return CreatedAtAction("Get", new { id = clientDtoAux.Id }, clientDtoAux);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ClientDTO clientDto)
        {
            try
            {
                var client = _mapper.Map<Client>(clientDto);

                if (id != client.Id)
                {
                    return BadRequest("The client ID does not match.");
                }

                var clientItem = await _clientRepository.GetClient(id);

                if (clientItem == null)
                {
                    return NotFound();
                }

                await _clientRepository.UpdateClient(client);

                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var client = await _clientRepository.GetClient(id);

                if (client == null)
                {
                    return NotFound();
                }

                await _clientRepository.DeleteClient(client);

                return NoContent();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [Route("[action]/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Disable(int id)
        {
            try
            {
                var client = await _clientRepository.GetClient(id);

                if (client == null)
                {
                    return NotFound();
                }

                await _clientRepository.DisableClient(client);

                return NoContent();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
