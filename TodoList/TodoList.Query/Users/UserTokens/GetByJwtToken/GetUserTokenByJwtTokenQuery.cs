using Common.Query;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Infrastructure.Persistent.Dapper;
using TodoList.Query.Users.DTOs;

namespace TodoList.Query.Users.UserTokens.GetByJwtToken
{
    public record GetUserTokenByJwtTokenQuery(string HashJwtToken) : IQuery<UserTokenDto?>;
    internal class GetUserTokenByJwtTokenQueryHandler : IQueryHandler<GetUserTokenByJwtTokenQuery, UserTokenDto>
    {
        private readonly DapperContext _dapperContext;

        public GetUserTokenByJwtTokenQueryHandler(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<UserTokenDto> Handle(GetUserTokenByJwtTokenQuery request, CancellationToken cancellationToken)
        {
            using var connection = _dapperContext.CreateConnection();
            var sql = $"SELECT TOP(1) * FROM {_dapperContext.UserTokens} Where HashJwtToken=@hashJwtToken";
            return await connection.QueryFirstOrDefaultAsync<UserTokenDto>(sql, new { hashJwtToken = request.HashJwtToken });
        }
    }
}
