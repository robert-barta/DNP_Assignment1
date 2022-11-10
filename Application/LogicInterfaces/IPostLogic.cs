using Shared;
using Shared.DTOs;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto dto);
    public Task<IEnumerable<Post>> GetAllPostsAsync();
    Task<IEnumerable<string>> GetAllTitlesAsync();
    
    Task<Post> GetByTitleAsync(string title);
}