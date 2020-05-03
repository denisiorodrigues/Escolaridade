using DR.Escolaridade.Domain.Interfaces;
using DR.Escolaridade.Infra.Data.Contex;

namespace DR.Escolaridade.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EscolaridadeContext _context;

        public UnitOfWork(EscolaridadeContext context)
        {
            _context = context;
        }

        //Opcional
        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        //Opcional
        public void Rollback()
        {
            _context.Database.CurrentTransaction.Rollback();
        }
        
        //Opcional
        public void Commit()
        {
            _context.Database.CurrentTransaction.Commit();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}