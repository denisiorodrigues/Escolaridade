using System.Web.Mvc;

namespace DR.Escolaridade.Infra.CrossCutting.Filters
{
    public class GlobalActionLogger : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //LOG de auditoria
            //Model que preencheu, a view onde ocorreu
            //Dopis da configuração fo filtro na camada de presentation
            //Toda request esse método é chamado
            
            if (filterContext.Exception != null)
            {
                //Manipular Exception

                //Colocar aqui a funcinalidade pra logar
                //Injetar alguma LIB de tratamento de erro 
                // -> Gravar log de erro no BD
                // -> Email para o admin
                // -> Retornar cod de erro amigavel

                //Sempre Utilizar ASYNC
                filterContext.ExceptionHandled = false;
                filterContext.Result = new HttpStatusCodeResult(500);
            }

            base.OnActionExecuted(filterContext);
        }
    }
}
