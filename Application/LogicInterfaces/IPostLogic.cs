using Shared;
using Shared.DTOs;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto dto);
    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters);
    public Task<IEnumerable<Post>> GetAsync(PostReadingDto postReadingDto);
}