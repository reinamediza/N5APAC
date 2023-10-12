using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PAC.WebAPI.Filters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public virtual void OnAuthorization(AuthorizationFilterContext context)
        {
            var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].ToString();

            Guid token = Guid.Empty;

            if (string.IsNullOrEmpty(authorizationHeader) || !Guid.TryParse(authorizationHeader, out token))
            {
                // Si asigno un result se corta la ejecucion de la request y ya devuelve la response
                context.Result = new ObjectResult(new { Message = "No se encuentra el header de Authorization" })
                {
                    StatusCode = 401
                };
            }

        }

    }
}

