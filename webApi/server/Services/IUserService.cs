using System;
using server.Domain.Models;

namespace server.Services
{
    public interface IUserService
    {
        public void CheckCredentials(LoginForm loginForm);
    }
}
