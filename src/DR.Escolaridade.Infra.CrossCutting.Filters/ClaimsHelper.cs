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
            ClaimsIdentity userClaims = (ClaimsIdentity)HttpContext.Current.User.Identity;

            return ValidarClaimsUsuario(userClaims,claimName, claimValue) ? value : MvcHtmlString.Empty;
        }

        public static bool IfClaim(this WebViewPage value, string claimName, string claimValue)
        {
            ClaimsIdentity userClaims = (ClaimsIdentity)HttpContext.Current.User.Identity;

            return ValidarClaimsUsuario(userClaims, claimName, claimValue);
        }

        public static string IfClaimShow(this WebViewPage value, string claimName, string claimValue)
        {
            ClaimsIdentity userClaims = (ClaimsIdentity)HttpContext.Current.User.Identity;

            return ValidarClaimsUsuario(userClaims, claimName, claimValue) ? string.Empty : "disabled";
        }

        public static bool ValidarClaimsUsuario(ClaimsIdentity claimsIdentity, string claimName, string claimValue)
        {
            Claim claim = claimsIdentity.Claims.FirstOrDefault(c => c.Type == claimName);

            return claim != null && claim.Value.Contains(claimValue);
        }
    }
}