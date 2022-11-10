using Shared;
using Shared.DTOs;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
 Task<User> CreateAsync(UserCreationDto userToCreate);
 Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchUserParametersDto);

 Task LoginAsync(UserCreationDto dto);
}