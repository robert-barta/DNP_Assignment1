namespace Shared.DTOs;

public class PostCreationDto
{
    public string UserName { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }

    public PostCreationDto(string title, string body, string userName)
    {
        UserName=userName;
        Title = title;
        Body = body;
    }

    public PostCreationDto()
    {
        
    }
}