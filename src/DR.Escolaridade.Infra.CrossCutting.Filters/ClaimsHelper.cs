using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DR.Escolaridade.Infra.CrossCutting.Filters
{
    public static class ClaimsHelper
    {
        //Quando colocar o nome "this" dentrod o parâmertro indormo que esse métoo vais er ciado dentroda classe "MvcHtmlString" por exemplo
        public static MvcHtmlString IfClaimHelper(this MvcHtmlString value, string claimName, string claimValue)
        {
            return ValidarClaimsUsuario(claimName, claimValue) ? value : MvcHtmlString.Empty;
        }

        public static bool IfClaim(this WebViewPage value, string claimName, string claimValue)
        {
            return ValidarClaimsUsuario(claimName, claimValue);
        }

        public static string IfClaimShow(this WebViewPage value, string claimName, string claimValue)
        {
            return ValidarClaimsUsuario(claimName, claimValue) ? string.Empty : "disabled";
        }

        public static bool ValidarClaimsUsuario(string claimName, string claimValue)
        {
            var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
            var claim = identity.Claims.FirstOrDefault(c => c.Type == claimName);
            return claim != null && claim.Value.Contains(claimValue);
        }
    }
}