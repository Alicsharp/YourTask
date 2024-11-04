using Common.Application;
using Common.Application.SecurityUtil;
using MediatR;
using TodoList.Application.User.AddToken;
using TodoList.Application.User.ChangePassword;
using TodoList.Application.User.Create;
using TodoList.Application.User.Edit;
using TodoList.Application.User.Register;
using TodoList.Application.User.RemoveToken;
using TodoList.Query.Users.DTOs;
using TodoList.Query.Users.GetByFilter;
using TodoList.Query.Users.GetById;
using TodoList.Query.Users.GetByPhoneNumber;
using TodoList.Query.Users.UserTokens.GetByJwtToken;
using TodoList.Query.Users.UserTokens.GetByRefreshToken;

namespace TodoList.Presentation.Facade.Users
{
    internal class UserFacade : IUserFacade
    {
        private readonly IMediator _mediator;

        public UserFacade(IMediator mediator)
        {
            _mediator = mediator;
        }


        public async Task<OperationResult> CreateUser(CreateUserCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> AddToken(AddUserTokenCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> RemoveToken(RemoveUserTokenCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> ChangePassword(ChangeUserPasswordCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditUser(EditUserCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<UserDto?> GetUserById(long userId)
        {
            return await _mediator.Send(new GetUserByIdQuery(userId));
        }

        public async Task<UserTokenDto?> GetUserTokenByRefreshToken(string refreshToken)
        {
            var hashRefreshToken = Sha256Hasher.Hash(refreshToken);
            return await _mediator.Send(new GetUserTokenByRefreshTokenQuery(hashRefreshToken));
        }

        public async Task<UserTokenDto?> GetUserTokenByJwtToken(string jwtToken)
        {
            var hashJwtToken = Sha256Hasher.Hash(jwtToken);
            return await _mediator.Send(new GetUserTokenByJwtTokenQuery(hashJwtToken));
        }

        public async Task<UserFilterResult> GetUserByFilter(UserFilterParams filterParams)
        {
            return await _mediator.Send(new GetUserByFilterQuery(filterParams));
        }

        public async Task<UserDto?> GetUserByPhoneNumber(string phoneNumber)
        {
            return await _mediator.Send(new GetUserByPhoneNumberQuery(phoneNumber));
        }

        public async Task<OperationResult> RegisterUser(RegisterUserCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
