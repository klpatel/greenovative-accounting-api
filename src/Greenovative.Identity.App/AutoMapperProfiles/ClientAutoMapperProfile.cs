using AutoMapper;
using Greenovative.Identity.App.ViewModels;
using Greenovative.Identity.Infrastructure.ClientModels;

namespace Greenovative.Identity.App.AutoMapperProfiles;

public class ClientAutoMapperProfile : Profile
{
    public ClientAutoMapperProfile()
    {
        CreateMap<Client, RBAClientViewModel>(MemberList.Destination);
        //Used MapPath for reverse mapping and generating Contact object for email
        CreateMap<RBAClientViewModel, Client>(MemberList.Source)
                .ForPath(x => x.Contact.Email1,
                    m => m.MapFrom(x => x.EmailId));

    }
}
