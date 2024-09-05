using Greenovative.Identity.App.ViewModels;
using MediatR;

namespace Greenovative.Identity.App.Application.Requests;

public class RegistrationCommand : IRequest<UserViewModel>
{
    public UserViewModel Users { get; set; }

}
