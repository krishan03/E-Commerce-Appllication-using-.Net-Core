using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AmCart.IAMModule.IdentityProvider
{
    public class ProfileService : IProfileService
    {
        private readonly IUserRepository repository;

        public ProfileService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            {
                //depending on the scope accessing the user data.
                if (!string.IsNullOrEmpty(context.Subject.Identity.Name))
                {
                    //get user from db (in my case this is by email)
                    var user = await repository.GetUserByUsernameAsync(context.Subject.Identity.Name);

                    if (user != null)
                    {
                        var claims = user.GetClaims();
                        //set issued claims to return
                        context.IssuedClaims = claims.Where(x => context.RequestedClaimTypes.Contains(x.Type)).ToList();
                    }
                }
                else
                {
                    //get subject from context (this was set ResourceOwnerPasswordValidator.ValidateAsync),
                    //where and subject was set to my user id.
                    string userId = context.Subject.Claims.FirstOrDefault(x => x.Type == "sub").Value;

                    if (!string.IsNullOrEmpty(userId))
                    {
                        //get user from db (find user by user id)
                        var user = await repository.GetUserAsync(userId);

                        // issue the claims for the user
                        if (user != null)
                        {
                            var claims = user.GetClaims();
                            context.IssuedClaims = claims.Where(x => context.RequestedClaimTypes.Contains(x.Type)).ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while executing the request", ex);
            }
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            try
            {
                //get subject from context (set in ResourceOwnerPasswordValidator.ValidateAsync),
                var userId = context.Subject.Claims.FirstOrDefault(x => x.Type == "user_id");
                if (!string.IsNullOrEmpty(userId?.Value) && long.Parse(userId.Value) > 0)
                {
                    var user = await repository.GetUserAsync(userId.Value);

                    if (user != null)
                    {
                        if (user.IsActive)
                        {
                            context.IsActive = user.IsActive;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while executing the request", ex);
            }
        }
    }
}
