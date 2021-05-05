using System;
using server.Domain.Models;

namespace server.Services
{
    public interface IUserService
    {
        // <summary>Checking user credentials for login</summary>
        // <param name="loginForm">Object that contains the data to be checked</param>
        // <exception>AuthenticationException when credentials are incorrect</exception>
        public void CheckCredentials(LoginForm loginForm);
    }
}
