using DomainValidation.Validation;
using DR.Escolaridade.Domain.Interfaces;

namespace DR.Escolaridade.Application.Services
{
    public abstract class AppServiceBase
    {
        private readonly IUnitOfWork _uow;

        public AppServiceBase(IUnitOfWork uow)
        {
            _uow = uow;
        }

        protected void AdicionarErroValidacao(ValidationResult validationResult, string erro)
        {
            validationResult.Add(new ValidationError(erro));
        }

        //Opcional
        protected void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        //Opcional
        protected void Rollback()
        {
            _uow.Rollback();
        }

        //Opcional
        protected void Commit()
        {
            _uow.Commit();
        }

        protected bool SaveChanges()
        {
            return _uow.SaveChanges();
        }
    }
}