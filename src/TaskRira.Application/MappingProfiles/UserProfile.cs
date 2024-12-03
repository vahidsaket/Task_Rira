using AutoMapper;
using TaskRira.Application.Models.User;
using TaskRira.Core.Entities;

namespace TaskRira.Application.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserModel, ApplicationUser>();
            CreateMap<UpdateUserModel, ApplicationUser>();
            CreateMap<ApplicationUser, SelectUserModel>()
                .ForMember(model => model.UserId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
