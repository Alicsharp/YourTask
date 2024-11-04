using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.ToDoAgg.Services;
using TodoList.Domain.UserAgg.Repository;
using TodoList.Infrastructure.Persistent.Dapper;
using TodoList.Infrastructure.Persistent.Ef;
using TodoList.Infrastructure.Persistent.Ef.TodoAgg;
using TodoList.Infrastructure.Persistent.Ef.UserAgg;

namespace TodoList.Infrastructure
{
    public class InfrastructureBootstrapper
    {
        public static void Init(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITodoRepository, TodoRepository>();
            services.AddTransient(_ => new DapperContext(connectionString));
            services.AddDbContext<ToDoContext>(option =>
            {
                option.UseSqlServer(connectionString);

            });
        }
    }
}
