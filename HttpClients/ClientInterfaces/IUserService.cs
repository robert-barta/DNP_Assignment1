using System.Security.Claims;
using Shared;
using Shared.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<User> Create(UserCreationDto dto);
    Task<IEnumerable<User>> GetUsersAsync(string? usernameContains = null);
    
    public Task LoginAsync(UserCreationDto dto);
    public Task LogoutAsync();
    public Task RegisterAsync(UserCreationDto dto);
    public Task<ClaimsPrincipal> GetAuthAsync();

    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }

    public Task CreateAsync(UserCreationDto dto);
}