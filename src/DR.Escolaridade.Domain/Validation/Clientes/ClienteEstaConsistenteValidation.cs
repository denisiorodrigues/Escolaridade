using DomainValidation.Validation;
using DR.Escolaridade.Domain.Models;
using DR.Escolaridade.Domain.Specification;
using DR.Escolaridade.Domain.Specification.Clientes;

namespace DR.Escolaridade.Domain.Validation.Clientes
{
    public class ClienteEstaConsistenteValidation :Validator<Cliente>
    {
        public ClienteEstaConsistenteValidation()
        {

            var CPFCliente = new ClienteDeveTerCpfValidoSpecification();
            var clienteEmail = new ClienteDeveTerEmailValidoSpecification();
            var clienteMaioridade = new ClienteDeveSerMaiorDeIdadeSpecification();
            var clienteNomeCurto = new GenericSpecification<Cliente>(c => c.Nome.Length >= 2); // Tem que ter

            //Pode colocar a mensagem de erro em um arquivo Resource
            Add("CPFCliente", new Rule<Cliente>(CPFCliente, "Cliente informou um CPF inválido."));
            Add("clienteEmail", new Rule<Cliente>(clienteEmail, "Cliente informou um e-amil inválido."));
            Add("clienteMaioridade", new Rule<Cliente>(clienteMaioridade, "Cliente não tem maioridade para cadastro."));
            Add("clienteNomeCurto", new Rule<Cliente>(clienteNomeCurto, "Nome do cliente precisa ter mais de 2 caracteres."));
        }
    }
}