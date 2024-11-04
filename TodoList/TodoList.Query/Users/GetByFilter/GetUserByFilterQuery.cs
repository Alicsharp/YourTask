using Common.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Query.Users.DTOs;

namespace TodoList.Query.Users.GetByFilter
{
    public class GetUserByFilterQuery : QueryFilter<UserFilterResult, UserFilterParams>
    {
        public GetUserByFilterQuery(UserFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
