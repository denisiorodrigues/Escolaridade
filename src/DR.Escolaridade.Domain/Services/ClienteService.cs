using DR.Escolaridade.Domain.Interfaces;
using DR.Escolaridade.Domain.Models;
using DR.Escolaridade.Domain.Validation.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.Escolaridade.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        //Ver o vídeo de SOLLID -> Injeção de depenência
        public ClienteService(IClienteRepository clienteRepository)
        {
            this._clienteRepository = clienteRepository;
        }

        public Cliente Adicionar(Cliente cliente)
        {
            if (!cliente.EhValido()) return cliente;

            cliente.ValidationResult = new ClienteEstaAptoParaCadastroValidation(_clienteRepository).Validate(cliente);

            if (cliente.ValidationResult.IsValid) _clienteRepository.Adicionar(cliente);

            return cliente;
        }

        public Cliente Atualizar(Cliente cliente)
        {
            if (!cliente.EhValido()) return cliente;

            _clienteRepository.Atualizar(cliente);
            return cliente;
        }

        public void Remover(Guid id)
        {
            _clienteRepository.Remover(id);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }
    }
}