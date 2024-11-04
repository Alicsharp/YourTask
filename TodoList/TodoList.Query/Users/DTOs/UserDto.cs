using Common.Query;
using Common.Query.Filter;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Query.Users.DTOs
{
    public class UserDto:BaseDto
    {
            public string Name { get; set; }
            public string Family { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }

    }
    public class UserFilterData : BaseDto
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }

    }
    public class UserFilterParams : BaseFilterParam
    {
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public long? Id { get; set; }
    }
    public class UserFilterResult : BaseFilter<UserFilterData, UserFilterParams>
    {

    }
}
