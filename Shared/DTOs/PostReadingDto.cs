namespace Shared.DTOs;

public class PostReadingDto
{
    public string? Title { get; }

    public PostReadingDto(string? title)
    {
        Title = title;
    }
}