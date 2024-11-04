using Common.Application;
using TodoList.Domain.UserAgg.Repository;
using TodoList.Domain.UserAgg.Services;

namespace TodoList.Application.User.Edit
{
    internal partial class EditUserCommandHandler : IBaseCommandHandler<EditUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserDomainService _userDomainService;

        public EditUserCommandHandler(IUserRepository userRepository, IUserDomainService userDomainService)
        {
            _userRepository = userRepository;
            _userDomainService = userDomainService;
        }

        public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetTracking(request.UserId);
            user.Edit(request.Name, request.Family, request.PhoneNumber, request.Email, _userDomainService);
            await _userRepository.Save();
            return OperationResult.Success();


        }
    }
}
