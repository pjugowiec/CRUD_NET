using System;
namespace server.Domain.Models
{
    [Serializable]
    public class LoginForm
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
