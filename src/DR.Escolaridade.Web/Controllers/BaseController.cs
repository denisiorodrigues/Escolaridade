using DomainValidation.Validation;
using System.Web.Mvc;

namespace DR.Escolaridade.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected void PopularModelStateComErros(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Erros)
            {
                ModelState.AddModelError(string.Empty, erro.Message);
            }
        }
    }
}