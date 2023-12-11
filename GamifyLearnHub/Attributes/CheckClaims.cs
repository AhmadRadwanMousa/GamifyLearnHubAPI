using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GamifyLearnHub.Attributes
{
    public class CheckClaims : Attribute, IAuthorizationFilter
    {
       private readonly string _claimType;
       private readonly string _claimValue;
        public CheckClaims(string claimType,string claimValue)
        {
            _claimType = claimType;
            _claimValue = claimValue;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.HasClaim(_claimType, _claimValue))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
