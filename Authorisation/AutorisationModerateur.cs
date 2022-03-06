using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using NetAtlas.Authorisation.ContactManager.Authorization;
using NetAtlas.Models;

namespace NetAtlas.Authorisation
{

    public class AutorisationModerateur :
        AuthorizationHandler<OperationAuthorizationRequirement, Publication>
        {
            protected override Task
                HandleRequirementAsync(AuthorizationHandlerContext context,
                                       OperationAuthorizationRequirement requirement,
                                       Publication resource)
            {
                if (context.User == null || resource == null)
                {
                    return Task.CompletedTask;
                }

                // If not asking for approval/reject, return.
                if (requirement.Name != Constants.ApproveOperationName &&
                    requirement.Name != Constants.RejectOperationName)
                {
                    return Task.CompletedTask;
                }

                // Managers can approve or reject.
                if (context.User.IsInRole(Constants.PublicationManagersRole))
                {
                    context.Succeed(requirement);
                }

                return Task.CompletedTask;
            }
        }
    }

