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

    public Task<IEnumerable<Post>> GetAllPostsAsync()
    {
        IEnumerable<Post> posts = context.Posts.AsEnumerable();
        posts = context.Posts;
        return Task.FromResult(posts);
    }
    
    public Task<Post?> GetByTitleAsync(string title)
    {
        Post? existing = context.Posts.FirstOrDefault
            (p => p.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(existing);
    }

    public Task<IEnumerable<string>> GetAllByTitleAsync()
    {
        var list = new List<string>();
        foreach (var contextPost in context.Posts)
        {
            list.Add(contextPost.Title);
        }

        return Task.FromResult(list.AsEnumerable());
    }
}