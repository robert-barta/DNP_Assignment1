using Application.DAOInterfaces;
using Shared;
using Shared.DTOs;

namespace FileData.DAOs;

public class PostFileDao:IPostDao
{
    private readonly FileContext context;

    public PostFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Post> CreateAsync(Post post)
    {
        int id = 1;

        if (context.Posts.Any())
        {
            id = context.Posts.Max(t => t.Id);
            id++;
        }

        post.Id = id;
        context.Posts.Add(post);
        context.SaveChanges();
        return Task.FromResult(post);
    }
    

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters)
    {
        IEnumerable<Post> posts = context.Posts.AsEnumerable();

        return Task.FromResult(posts);
    }
    

    public Task<IEnumerable<Post>> GetAsync(PostReadingDto postReadingDto)
    {
        IEnumerable<Post> posts = context.Posts.AsEnumerable();
        if (postReadingDto.Title !=null)
        {
            posts = context.Posts.Where(p =>
                p.Title.Contains(postReadingDto.Title, StringComparison.OrdinalIgnoreCase));
        }
        return Task.FromResult(posts);
    }

  
    
    
}