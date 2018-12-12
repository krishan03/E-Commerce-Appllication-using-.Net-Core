using Amcart.Core.Domain;
using System.Collections.Generic;

namespace AmCart.Business.IAM
{
    public class User : DomainBase
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailId { get; set; }

        public string Password { get; set; }

        public bool IsVerified { get; set; }

        public Role Role { get; set; }

        public IList<string> Permissions { get; set; }
    }
}
