using TodoList.Domain.UserAgg;
using TodoList.Query.Users.DTOs;

namespace TodoList.Query.Users
{
    public static class UserMapper
    {
        public static UserDto Map(this User user)
        {
            return new UserDto()
            {
                Id = user.Id,
                CreationDate = user.CreationDate,
                Family = user.Family,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Name = user.Name,
                Password = user.Password,

            };
        }
        public static UserFilterData MapFilterData(this User user)
        {
            return new UserFilterData()
            {
                Id = user.Id,
                CreationDate = user.CreationDate,
                Family = user.Family,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Name = user.Name
            };
        }
    }
}
