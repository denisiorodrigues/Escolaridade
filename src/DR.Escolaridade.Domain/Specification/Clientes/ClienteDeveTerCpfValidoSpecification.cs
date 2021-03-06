﻿using DomainValidation.Interfaces.Specification;
using DR.Escolaridade.Domain.Models;
using DR.Escolaridade.Domain.ValueObject;

namespace DR.Escolaridade.Domain.Specification.Clientes
{
    public class ClienteDeveTerCpfValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente entity)
        {
            return CPF.Validar(entity.CPF);
        }
    }
}