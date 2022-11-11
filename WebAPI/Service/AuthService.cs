using System.ComponentModel.DataAnnotations;
using Shared;

namespace WebAPI.Service;

public class AuthService :IAuthService
{

    private readonly IList<User> users = new List<User>
    {
        new User()
        {
            UserName = "Robert",
            Id = 1,
            Password = "1234"
        }
    };

    public Task<User> ValidateUser(string username, string password)
    {
        User? existingUser = users.FirstOrDefault(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));

        if (existingUser!=null)
        {
            throw new Exception("User already existing.");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Wrong password!");
        }

        return Task.FromResult(existingUser);

    }
    
    public Task<User> GetUser(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task RegisterUser(User user)
    {

        if (string.IsNullOrEmpty(user.UserName))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be null");
        }

        users.Add(user);
        
        return Task.CompletedTask;
    }
}