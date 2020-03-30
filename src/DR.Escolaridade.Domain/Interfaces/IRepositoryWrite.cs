using DR.Escolaridade.Domain.Models;
using System;

namespace DR.Escolaridade.Domain.Interfaces
{
    public interface IRepositoryWrite<TEntity> : IDisposable where TEntity : Entity
    {
        void Adicionar(TEntity entity);

        void Atualizar(TEntity entity);

        void Remover(Guid id);

        int SaveChanges();
    }
}