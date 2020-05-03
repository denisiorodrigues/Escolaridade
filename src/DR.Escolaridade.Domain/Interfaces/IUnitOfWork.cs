namespace DR.Escolaridade.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Rollback();
        void Commit();
        bool SaveChanges();
    }
}