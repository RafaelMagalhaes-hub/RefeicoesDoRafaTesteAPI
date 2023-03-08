using Microsoft.AspNetCore.Mvc;
using RefeicoesDoRafaAPI.Dao;
using RefeicoesDoRafaAPI.Models;

namespace RefeicoesDoRafaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly Context _context;

        public ClienteController(ILogger<ClienteController> logger, Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ClienteDTO> Get()
        {
            var clientes = _context.cliente.ToArray();
            var clientesDTO = new List<ClienteDTO>();

            foreach (var cliente in clientes) 
            {
                var endereco = _context.Find<Endereco>(cliente.enderecoid);
                var clienteDTO = new ClienteDTO()
                {
                    nomeCompletoCliente = cliente.nomeCompletoCliente,
                    cpf = cliente.cpf,
                    email = cliente.email,
                    whatsapp = cliente.whatsapp,
                    endereco = new EnderecoDTO()
                    { 
                        cep = endereco.cep,
                        numero = endereco.numero,
                        complemento = endereco.complemento
                    }
                };
                clientesDTO.Add(clienteDTO);
            }

            return clientesDTO.ToArray();
        }

        [HttpPost]
        public void Post(ClienteDTO clienteDTO)
        {
            var cliente = new Cliente() 
            {
                nomeCompletoCliente = clienteDTO.nomeCompletoCliente,
                cpf = clienteDTO.cpf,
                email = clienteDTO.email,
                whatsapp= clienteDTO.whatsapp,
                endereco = new Endereco() 
                { 
                    cep = clienteDTO.endereco.cep,
                    numero=clienteDTO.endereco.numero,
                    complemento=clienteDTO.endereco.complemento
                }
            };
            
            _context.Add(cliente);
            _context.SaveChanges();
        }

        [HttpDelete]
        public void Delete(string cpf)
        {
            var cliente = _context.Find<Cliente>(cpf);
            _context.Remove<Cliente>(cliente);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Put(ClienteDTO clienteDTO)
        {
            var cliente = new Cliente() 
            {
                cpf = clienteDTO.cpf,
                nomeCompletoCliente = clienteDTO.nomeCompletoCliente,
                email = clienteDTO.email,
                whatsapp = clienteDTO.whatsapp,
                endereco = new Endereco() 
                {
                    cep = clienteDTO.endereco.cep,
                    numero = clienteDTO.endereco.numero,
                    complemento = clienteDTO.endereco.complemento
                }
            };

            _context.Update<Cliente>(cliente);
            _context.SaveChanges();
        }

    }
}