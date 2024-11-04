using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Presentation.Facade.Todo;
using TodoList.Presentation.Facade.Users;

namespace TodoList.Presentation.Facade
{
    public static class FacadeBootstrapper
    {
        public static void InitFacadeDependency(this IServiceCollection services)
        {
           
            services.AddScoped<ITodoFacade, TodoFacade>();
            services.AddScoped<IUserFacade, UserFacade>();

        }
    }
}
