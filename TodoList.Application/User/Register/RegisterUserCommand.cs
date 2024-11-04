using Common.Application;
using Common.Application.SecurityUtil;
using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.UserAgg.Repository;
using TodoList.Domain.UserAgg.Services;

namespace TodoList.Application.User.Register
{
    public class RegisterUserCommand : IBaseCommand
    {
        public RegisterUserCommand(PhoneNumber phoneNumber, string password)
        {
            PhoneNumber = phoneNumber;
            Password = password;
        }
        public PhoneNumber PhoneNumber { get; private set; }
        public string Password { get; private set; }
    }
    internal class RegisterUserCommandHandler : IBaseCommandHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IUserDomainService _domainService;

        public RegisterUserCommandHandler(IUserRepository repository, IUserDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = TodoList.Domain.UserAgg.User.RegisterUser(request.PhoneNumber.Value, Sha256Hasher.Hash(request.Password), _domainService);

            _repository.Add(user);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
