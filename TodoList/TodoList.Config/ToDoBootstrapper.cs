using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Application.Todo.Item.Create;
using TodoList.Application.User;
using TodoList.Application.User.Create;
using TodoList.Domain.UserAgg.Services;
using TodoList.Infrastructure;
using TodoList.Presentation.Facade;
using TodoList.Query.Users.GetByPhoneNumber;

namespace TodoList.Config
{
    public static class ToDoBootstrapper
    {
        public static void RegisterToDoDependency(this IServiceCollection services, string connectionString)
        {
            InfrastructureBootstrapper.Init(services, connectionString);
            services.AddMediatR(cfg =>
                         cfg.RegisterServicesFromAssembly(typeof(AddToDoItemCommand).Assembly));

            services.AddMediatR(cfg =>
                    cfg.RegisterServicesFromAssembly(typeof(GetUserByPhoneNumberQuery).Assembly));
            services.AddTransient<IUserDomainService, UserDomainService>();

            services.AddValidatorsFromAssembly(typeof(CreateUserCommandValidator).Assembly);
            FacadeBootstrapper.InitFacadeDependency(services);
        }
    }
}
