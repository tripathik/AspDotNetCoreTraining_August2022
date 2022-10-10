using System.ComponentModel.DataAnnotations;

namespace WFM_API.Wfm_Core.ViewModel
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }

}
