using Application.DAOInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared;
using Shared.DTOs;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDao
{
    private readonly PostContext context;

    public PostEfcDao(PostContext context)
    {
        this.context = context;
    }

    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> added = await context.Todos.AddAsync(post);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters)
    {
        IQueryable<Post> query = context.Todos.Include(todo => todo.Owner).AsQueryable();
    
        if (!string.IsNullOrEmpty(searchParameters.Username))
        {
            query = query.Where(todo =>
                todo.Owner.UserName.ToLower().Equals(searchParameters.Username.ToLower()));
        }
    
        if (searchParameters.UserId != null)
        {
            query = query.Where(t => t.Owner.Id == searchParameters.UserId);
        }
        
        if (!string.IsNullOrEmpty(searchParameters.TitleContains))
        {
            query = query.Where(t =>
                t.Title.ToLower().Contains(searchParameters.TitleContains.ToLower()));
        }

        List<Post> result = await query.ToListAsync();
        return result;
    }

    public Task<IEnumerable<Post>> GetAsync(PostReadingDto postReadingDto)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Post>> GetAllPostsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Post?> GetByTitleAsync(string title)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<string>> GetAllByTitleAsync()
    {
        throw new NotImplementedException();
    }
}