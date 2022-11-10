namespace WebAPI.Controllers;
using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.DTOs;


[ApiController]
[Route("[controller]")]
public class PostsController:ControllerBase
{
    private readonly IPostLogic PostLogic;

    public PostsController(IPostLogic postLogic)
    {
        PostLogic = postLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreateAsync([FromBody] PostCreationDto dto)
    {
        try
        {
            Post created = await PostLogic.CreateAsync(dto);
            return Created($"/posts/{created.Id}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAllAsync()
    {
        try
        {
            
            IEnumerable<Post> posts = await PostLogic.GetAllPostsAsync();
            return Ok(posts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("/title")]
    public async Task<ActionResult<Post>> GetByTitleAsync([FromQuery] string title)
    {
        try
        {
            Post post = await PostLogic.GetByTitleAsync(title);
            return Ok(post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("/titles")]
    public async Task<ActionResult<IEnumerable<string>>> GetAllByTitleAsync()
    {
        try
        {
            IEnumerable<string> posts= await PostLogic.GetAllTitlesAsync();
            return Ok(posts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}