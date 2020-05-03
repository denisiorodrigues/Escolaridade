using DomainValidation.Validation;
using DR.Escolaridade.Domain.Interfaces;
using DR.Escolaridade.Domain.Models;
using DR.Escolaridade.Domain.Specification.Clientes;

namespace DR.Escolaridade.Domain.Validation.Clientes
{
    public class ClienteEstaAptoParaCadastroValidation : Validator<Cliente>
    {
        public ClienteEstaAptoParaCadastroValidation(IClienteRepository clienteRepository)
        {
            var clienteUnicoCpf = new ClienteDevePossuirCPFUnicoSpecification(clienteRepository);
            var clienteUnicoEmail = new ClienteDevePossuirEmailUnicoSpecification(clienteRepository);

            //Pode colocar a mensagem de erro em um arquivo Resource
            Add("clienteUnicoCpf", new Rule<Cliente>(clienteUnicoCpf, "Já existe um cliente com esse CPF."));
            Add("clienteUnicoEmail", new Rule<Cliente>(clienteUnicoEmail, "Já existe um cliente com esse E-mail."));
        }
    }
}