using AutoMapper;
using Greenovative.Identity.App.ViewModels;
using Greenovative.Identity.Infrastructure.Models;

namespace Greenovative.Identity.App.AutoMapperProfiles;

public class UserAutoMapperProfile : Profile
{
    public UserAutoMapperProfile()
    {
        CreateMap<User, UserViewModel>(MemberList.Destination);
        CreateMap<UserViewModel, User>(MemberList.Source);
    }
}
public class UserRoleMapperProfile : Profile
{
    public UserRoleMapperProfile()
    {
        CreateMap<AspNetUserRole, UserClientRoleViewModel>(MemberList.Destination);
        CreateMap<UserClientRoleViewModel, AspNetUserRole>(MemberList.Source);

    }
}
