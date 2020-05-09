using DR.Escolaridade.Application.Interfaces;
using DR.Escolaridade.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace DR.Escolaridade.REST.ClienteAPI.Controllers
{
    //Jeito Manual
    //[EnableCors(origins: "http://globo.com", headers: "*", methods: "GET,POST")]
    //Jeitoautomático via classe
    [MyCorsPolicy]
    public class ClientesController : ApiController
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        public IEnumerable<ClienteViewModel> Get()
        {
            return _clienteAppService.ObterAtivos();
        }

        public ClienteViewModel Get(Guid id)
        {
            return _clienteAppService.ObterPorId(id);
        }

        public IHttpActionResult Post([FromBody]ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();
            _clienteAppService.Adicionar(clienteEnderecoViewModel);
            return Ok();
        }

        public IHttpActionResult Put(Guid id, [FromBody]ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();
            _clienteAppService.Atualizar(clienteViewModel);
            return Ok();
        }

        public void Delete(Guid id)
        {
            _clienteAppService.Remover(id);
        }
    }
}