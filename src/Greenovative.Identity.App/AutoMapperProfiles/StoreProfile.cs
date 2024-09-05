using AutoMapper;
using Greenovative.Identity.App.ViewModels;
using Greenovative.Identity.Infrastructure.ClientModels;

namespace Greenovative.Identity.App.AutoMapperProfiles;

public class StoreProfile : Profile
{
    public StoreProfile()
    {
        CreateMap<Store, StoreViewModel>(MemberList.Destination);
        CreateMap<StoreViewModel, Store>(MemberList.Source);

    }
}
