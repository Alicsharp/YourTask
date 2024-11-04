using AutoMapper;
using Todo.Api.ViewModels.Users;
using TodoList.Application.User.ChangePassword;

namespace Todo.Api.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
             
            CreateMap<ChangePasswordViewModel, ChangeUserPasswordCommand>().ReverseMap();
        }
    }
}
