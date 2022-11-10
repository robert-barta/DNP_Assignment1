using Shared;
using Shared.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task CreateAsync(PostCreationDto dto);
    Task<ICollection<Post>> GetAsync(string? username, int? userId, string? titleContains);

    Task<ICollection<string>> GetTitlesAsync();

    Task<Post> GetByTitleAsync(string title);

}