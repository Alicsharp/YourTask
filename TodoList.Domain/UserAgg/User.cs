using Common.Domain;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.ToDoAgg;
using TodoList.Domain.UserAgg.Services;

namespace TodoList.Domain.UserAgg
{
    public class User : AggregateRoot
    {
        public User(string name, string family, string phoneNumber, string email, string password, IUserDomainService userDomainService)
        {
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Tokens = new();
            ItemLists = new List<ItemList>();  // رابطه یک به چند با ItemList
        }

        public User() { }

        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public List<UserToken> Tokens { get; }

        // لیست ItemList که به کاربر تعلق دارد (رابطه یک به چند)
        public List<ItemList> ItemLists { get; private set; }

        public void Edit(string name, string family, string phoneNumber, string email,  IUserDomainService userDomainService)
        {
            Guard(phoneNumber, email, userDomainService);
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            
        }
        public void ChangePassword(string newPassword)
        {
            NullOrEmptyDomainDataException.CheckString(newPassword, nameof(newPassword));

            Password = newPassword;
        }
        public static User RegisterUser(string phoneNumber, string password, IUserDomainService userDomainService)
        {
            return new User("", "", phoneNumber, null, password , userDomainService);
        }
        public void AddToken(string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
        {
            var activeTokenCount = Tokens.Count(c => c.RefreshTokenExpireDate > DateTime.Now);
            if (activeTokenCount == 3)
                throw new InvalidDomainDataException("امکان استفاده از 4 دستگاه همزمان وجود ندارد");

            var token = new UserToken(hashJwtToken, hashRefreshToken, tokenExpireDate, refreshTokenExpireDate, device);
            token.UserId = Id;
            Tokens.Add(token);
        }
        public void RemoveToken(long tokenId)
        {
            var token = Tokens.FirstOrDefault(f => f.Id == tokenId);
            if (token == null)
                throw new InvalidDomainDataException("invalid TokenId");

            Tokens.Remove(token);
        }
        public void Guard(string phoneNumber, string email, IUserDomainService userDomainService)
        {
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));

            if (phoneNumber.Length != 11)
                throw new InvalidDomainDataException("شماره موبایل نامعتبر است");

            if (!string.IsNullOrWhiteSpace(email))
                if (email.IsValidEmail() == false)
                    throw new InvalidDomainDataException(" ایمیل  نامعتبر است");

            if (phoneNumber != PhoneNumber)
                if (userDomainService.PhoneNumberIsExist(phoneNumber))
                    throw new InvalidDomainDataException("شماره موبایل تکراری است");

            if (email != Email)
                if (userDomainService.IsEmailExist(email))
                    throw new InvalidDomainDataException("ایمیل تکراری است");
        }
    }
}
