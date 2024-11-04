using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.UserAgg.Repository;
using TodoList.Domain.UserAgg.Services;

namespace TodoList.Application.User
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUserRepository _repository;

        public UserDomainService(IUserRepository repository)
        {
            _repository = repository;
        }

        public bool IsEmailExist(string email)
        {
            return _repository.Exists(r => r.Email == email);
        }

        public bool PhoneNumberIsExist(string phoneNumber)
        {
            return _repository.Exists(r => r.PhoneNumber == phoneNumber);

        }
    }
}
 