using AutoMapper;
using Grpc.Server;
using TaskRira.Application.Models.User;

namespace TaskRira.Application.MappingProfiles
{
    public class UserModelProfile : Profile
    {
        public UserModelProfile()
        {
            CreateMap<SelectUserModel, UserDetails>();
            CreateMap<CreateUserDetailRequest, CreateUserModel>();
            CreateMap<SelectUserModel, UserDetails>();
        }
    }
}
