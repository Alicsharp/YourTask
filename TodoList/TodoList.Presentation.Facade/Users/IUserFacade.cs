using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application.User.AddToken;
using TodoList.Application.User.ChangePassword;
using TodoList.Application.User.Create;
using TodoList.Application.User.Edit;
using TodoList.Application.User.Register;
using TodoList.Application.User.RemoveToken;
using TodoList.Query.Users.DTOs;

namespace TodoList.Presentation.Facade.Users
{
    public interface IUserFacade
    {
        Task<OperationResult> RegisterUser(RegisterUserCommand command);
        Task<OperationResult> EditUser(EditUserCommand command);
        Task<OperationResult> CreateUser(CreateUserCommand command);
        Task<OperationResult> AddToken(AddUserTokenCommand command);
        Task<OperationResult> RemoveToken(RemoveUserTokenCommand command);
        Task<OperationResult> ChangePassword(ChangeUserPasswordCommand command);

        Task<UserDto?> GetUserByPhoneNumber(string phoneNumber);
        Task<UserDto?> GetUserById(long userId);
        Task<UserTokenDto?> GetUserTokenByRefreshToken(string refreshToken);
        Task<UserTokenDto?> GetUserTokenByJwtToken(string jwtToken);
        Task<UserFilterResult> GetUserByFilter(UserFilterParams filterParams);
    }
}
