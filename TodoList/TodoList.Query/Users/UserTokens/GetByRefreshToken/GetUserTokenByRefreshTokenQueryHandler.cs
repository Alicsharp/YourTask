﻿using Common.Query;
using Dapper;
using TodoList.Infrastructure.Persistent.Dapper;
using TodoList.Query.Users.DTOs;

namespace TodoList.Query.Users.UserTokens.GetByRefreshToken
{
    internal class GetUserTokenByRefreshTokenQueryHandler : IQueryHandler<GetUserTokenByRefreshTokenQuery, UserTokenDto>
    {
        private readonly DapperContext _dapperContext;

        public GetUserTokenByRefreshTokenQueryHandler(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<UserTokenDto> Handle(GetUserTokenByRefreshTokenQuery request, CancellationToken cancellationToken)
        {
            using var connection = _dapperContext.CreateConnection();
            var sql = $"SELECT TOP(1) * FROM {_dapperContext.UserTokens} Where HashRefreshToken=@hashRefreshToken";
            return await connection.QueryFirstOrDefaultAsync<UserTokenDto>(sql, new { hashRefreshToken = request.HashRefreshToken });
        }
    }
}
