using System.Security.Claims;
using HttpClients.ClientInterfaces;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorWASM.Auth;

public class CustomAuthProvider:AuthenticationStateProvider
{

    private readonly IUserService UserService;

    public CustomAuthProvider(IUserService UserService)
    {
        this.UserService = UserService;
        UserService.OnAuthStateChanged += AuthStateChanged;
    }
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        ClaimsPrincipal principal = await UserService.GetAuthAsync();
        
        return new AuthenticationState(principal);
    }
    
    private void AuthStateChanged(ClaimsPrincipal principal)
    {
        NotifyAuthenticationStateChanged(
            Task.FromResult(
                new AuthenticationState(principal)
            )
        );
    }
}