using Common.Application;
using Common.Application.SecurityUtil;
using TodoList.Domain.UserAgg.Repository;
using TodoList.Domain.UserAgg.Services;

namespace TodoList.Application.User.Create
{
    public class CreateUserCommandHandler : IBaseCommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserDomainService _userDomainService;

        public CreateUserCommandHandler(IUserRepository userRepository, IUserDomainService userDomainService)
        {
            _userRepository = userRepository;
            _userDomainService = userDomainService;
        }

        public async Task<OperationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var password = Sha256Hasher.Hash(request.Password);
            var user = new Domain.UserAgg.User(request.Name, request.Family, request.PhoneNumber, request.Email, password, _userDomainService);
            _userRepository.Add(user);
            await _userRepository.Save();
            return OperationResult.Success();
        }
    }
}
