using System.Security.Claims;
using Shared;
using Shared.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{

    public Task LoginAsync(string username, string password);
    public Task LogoutAsync();
    public Task<ClaimsPrincipal> GetAuthAsync();

    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }

    public Task CreateAsync(UserCreationDto dto);
}