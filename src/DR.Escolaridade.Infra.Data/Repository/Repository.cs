using DR.Escolaridade.Domain.Interfaces;
using DR.Escolaridade.Domain.Models;
using DR.Escolaridade.Infra.Data.Contex;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DR.Escolaridade.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepositoryRead<TEntity>, IRepositoryWrite<TEntity> where TEntity : Entity, new()
    {
        protected EscolaridadeContext Db;
        protected DbSet<TEntity> DbSet;

        protected Repository()
        {
            Db = new EscolaridadeContext();
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            SaveChanges();
        }

        public virtual void Atualizar(TEntity entity)
        {
            var entry = Db.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;

            SaveChanges();
        }

        public virtual void Remover(Guid id)
        {
            var entity = new TEntity() { Id = id };
            DbSet.Remove(entity);
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            //O FIND busca pela chave primária
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> ObterTodosPaginado(int pagina, int quantidade)
        {
            return DbSet.Take(quantidade).Skip(pagina).ToList();
        }

        public virtual int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public virtual void Dispose()
        {
            Db.Dispose();
        }
    }
}