﻿using System.Net.Http.Json;
using System.Text.Json;
using HttpClients.ClientInterfaces;
using Shared;
using Shared.DTOs;

namespace HttpClients.Implementations;

public class PostHttpClient :IPostService
{
    private readonly HttpClient client;

    public PostHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task CreateAsync(PostCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/posts", dto);
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }
    

    public async Task<ICollection<string>> GetTitlesAsync()
    {
        HttpResponseMessage response = await client.GetAsync("/titles");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        ICollection<string> titles = JsonSerializer.Deserialize<ICollection<string>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return titles;
    }

    public async Task<Post> GetByTitleAsync(string title)
    {
        string query = ConstructQuery(title);
        HttpResponseMessage response = await client.GetAsync("/title"+query);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        Post post = JsonSerializer.Deserialize<Post>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return post;
        
        
    }

    private static string ConstructQuery
        (string title)
    {
        string query = "";
        if (!string.IsNullOrEmpty(title))
        {
            query += $"?title={title}";
        }

        return query;
    }
}