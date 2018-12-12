using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace AmCart.IAM
{
    public class Config
    {
        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients()
        {
            // client credentials client
            return new List<Client>
            {
                new Client
                {
                    ClientId = "mvc.client",
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RequireConsent = false,

                    // where to redirect to after login
                    RedirectUris = { "http://localhost:4300/" },

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "http://localhost:62570" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    },

                    AllowAccessTokensViaBrowser = true
                }
            };
        }

        public static List<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile() // <-- usefull
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "rahul",
                    Password = "Passw0rd"
                }
            };
        }
    }
}
