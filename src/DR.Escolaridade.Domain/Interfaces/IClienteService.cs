using DR.Escolaridade.Domain.Models;
using System;

namespace DR.Escolaridade.Domain.Interfaces
{
    public interface IClienteService : IDisposable
    {
        Cliente Adicionar(Cliente cliente);

        Cliente Atualizar(Cliente cliente);

        void Remover(Guid id);
    }
}