using AutoMapper;
using Greenovative.Identity.App.ViewModels;
using Greenovative.Identity.Infrastructure.ClientModels;

namespace Greenovative.Identity.App.AutoMapperProfiles;

public class UserClientRoleMapperProfile : Profile
{
    public UserClientRoleMapperProfile()
    {
        CreateMap<UserClientRole, UserClientRoleViewModel>(MemberList.Destination);
        CreateMap<UserClientRoleViewModel, UserClientRole>(MemberList.Source);

    }
}
