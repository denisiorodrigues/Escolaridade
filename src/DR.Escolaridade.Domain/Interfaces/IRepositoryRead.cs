using DR.Escolaridade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DR.Escolaridade.Domain.Interfaces
{
    public interface IRepositoryRead<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity ObterPorId(Guid id);

        IEnumerable<TEntity> ObterTodos();

        IEnumerable<TEntity> ObterTodosPaginado(int pagina, int quantidade);

        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
    }
}