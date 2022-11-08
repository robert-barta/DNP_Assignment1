using Shared;
using Shared.DTOs;

namespace Application.DAOInterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByUsernameAsync(string userName);
    Task<User?> GetByIdAsync(int dtoOwnerId);

    Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchUserParametersDto);
}