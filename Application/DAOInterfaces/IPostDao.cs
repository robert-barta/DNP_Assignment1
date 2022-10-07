using Shared;

namespace Application.DAOInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
}