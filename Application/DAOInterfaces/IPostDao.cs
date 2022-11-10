using Shared;
using Shared.DTOs;

namespace Application.DAOInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters);
    public Task<IEnumerable<Post>> GetAsync(PostReadingDto postReadingDto);

    public Task<IEnumerable<Post>> GetAllPostsAsync();
    
    Task<Post?> GetByTitleAsync(string title);
    Task<IEnumerable<string>> GetAllByTitleAsync();
}