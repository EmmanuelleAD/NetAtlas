using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using NetAtlas.Authorisation.ContactManager.Authorization;
using NetAtlas.Models;
namespace NetAtlas.Authorisation
{
   
        public class AuthorisationAdminstrateur
                   : AuthorizationHandler<OperationAuthorizationRequirement, Publication>
        {
            protected override Task HandleRequirementAsync(
                                                  AuthorizationHandlerContext context,
                                        OperationAuthorizationRequirement requirement,
                                         Publication resource)
            {
                if (context.User == null)
                {
                    return Task.CompletedTask;
                }

                // Administrators can do anything.
                if (context.User.IsInRole(Constants.PublicationAdministratorsRole))
                {
                    context.Succeed(requirement);
                }

                return Task.CompletedTask;
            }
        }
    }

