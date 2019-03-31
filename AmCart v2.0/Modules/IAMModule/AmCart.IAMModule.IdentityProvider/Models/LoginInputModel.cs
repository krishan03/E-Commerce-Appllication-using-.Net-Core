using System.ComponentModel.DataAnnotations;

namespace AmCart.IAMModule.IdentityProvider
{
    public class LoginInputModel
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RequestToRegister { get; set; }

        public bool RememberLogin { get; set; }

        public string ReturnUrl { get; set; }
    }
}