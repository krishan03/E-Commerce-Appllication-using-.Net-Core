using AmCart.Business.IAM;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using System;
using System.Threading.Tasks;

namespace Amcart.Web.IAM
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUserRepository repository;

        public ResourceOwnerPasswordValidator(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            try
            {
                var user = await repository.ValidateUserAsync(context.UserName, context.Password);
                if (user != null)
                {
                    //set the result
                    context.Result = new GrantValidationResult(subject: user.Id.ToString(), authenticationMethod: "custom", claims: user.GetClaims());
                }
                else
                {
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidClient, "The Username Or Password is incorrect.");
                    return;
                }
            }
            catch (Exception)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Error occured while processing the request.");
            }
        }
    }
}
