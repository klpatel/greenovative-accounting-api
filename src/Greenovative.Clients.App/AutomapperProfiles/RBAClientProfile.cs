using AutoMapper;
using Greenovative.Clients.App.ViewModels;
using Greenovative.Clients.Infrastructure.Models;

namespace Greenovative.Clients.App.AutomapperProfiles;

public class RBAClientProfile : Profile
{
    public RBAClientProfile()
    {
        CreateMap<Client, RBAClientViewModel>(MemberList.Destination);
        CreateMap<RBAClientViewModel, Client>(MemberList.Source);

    }
}
