using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace DR.Escolaridade.Infra.CrossCutting.Filters
{
    public class ClaimsAuthorize : AuthorizeAttribute
    {
        public static string _claimName;
        public static string _claimValue;

        public ClaimsAuthorize(string claimName, string claimValue)
        {
            _claimName = claimName;
            _claimValue = claimValue;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //ClaimsIdentity userClaims = (ClaimsIdentity)httpContext.User.Identity; 
            //return ClaimsHelper.ValidarClaimsUsuario(userClaims, _claimName, _claimValue);
            var identity = (ClaimsIdentity)httpContext.User.Identity;
            var claim = identity.Claims.FirstOrDefault(c => c.Type == _claimName);
            return claim != null && claim.Value.Contains(_claimValue);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //Se já está autenticado vai para a página de não aturizado
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}