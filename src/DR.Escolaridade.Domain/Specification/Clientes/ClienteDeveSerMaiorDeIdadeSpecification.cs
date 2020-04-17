using DomainValidation.Interfaces.Specification;
using DR.Escolaridade.Domain.Models;
using System;

namespace DR.Escolaridade.Domain.Specification.Clientes
{
    public class ClienteDeveSerMaiorDeIdadeSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente entity)
        {
            return DateTime.Now.Year - entity.DataNascimento.Year >= 18;
        }
    }
}