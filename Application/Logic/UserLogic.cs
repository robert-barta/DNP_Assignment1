﻿using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Shared;
using Shared.DTOs;

namespace Application.Logic;

public class UserLogic:IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }
    
    public async Task<User> CreateAsync(UserCreationDto userToCreate)
    {
        User? existing = await userDao.GetByUsernameAsync(userToCreate.UserName);
        if (existing!=null)
        {
            throw new Exception("That username is already taken!");
        }

        
        User toCreate = new User
        {
            UserName = userToCreate.UserName,
            Password = userToCreate.Password
        };

        User created = await userDao.CreateAsync(toCreate);
        return created;
    }

    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchUserParametersDto)
    {
        return userDao.GetAsync(searchUserParametersDto);
    }

    public async Task<User> LoginAsync(UserCreationDto dto)
    {
        User? existing = await userDao.GetByUsernameAsync(dto.UserName);
        if (existing == null)
        {
            throw new Exception("Such user doesn't exist");
        }

        await ValidateData(dto);
        
        Console.Write($"{existing.UserName} : {existing.Password}");
        return existing;
    }

    public Task ValidateData(UserCreationDto userToCreate)
    {
        string userName = userToCreate.UserName;

        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters!");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");
        return Task.CompletedTask;
    }
    
}