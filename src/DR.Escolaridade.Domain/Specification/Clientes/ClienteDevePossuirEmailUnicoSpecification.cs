using DomainValidation.Interfaces.Specification;
using DR.Escolaridade.Domain.Interfaces;
using DR.Escolaridade.Domain.Models;

namespace DR.Escolaridade.Domain.Specification.Clientes
{
    public class ClienteDevePossuirEmailUnicoSpecification : ISpecification<Cliente>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteDevePossuirEmailUnicoSpecification(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool IsSatisfiedBy(Cliente cliente)
        {
            //Validação para verificvar se está atendendo a validação
            return _clienteRepository.ObterPorEmail(cliente.Email) == null;
        }
    }
}