namespace Shared;

public class Post
{
    public int Id { get; set; }
    public User Owner { get;private set; }
    public String Title { get; private set; }
    public String Body { get; set; }

    public Post(User owner, string title)
    {
        Owner = owner;
        Title = title;
       
    }

    private Post()
    {
        
    }
}