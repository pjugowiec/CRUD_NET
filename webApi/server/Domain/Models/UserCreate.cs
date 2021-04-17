using System;
using System.ComponentModel.DataAnnotations;

namespace server.Domain.Models
{
    [Serializable]
    public class UserModify
    {
        public long Id { get; set; }

        [Required]
        public string Login { get; set; }

        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public UserModify()
        {
        }
    }
}
