using AutoMapper;
using Greenovative.Accounting.Framework.Exceptions;
using Greenovative.Identity.App.ViewModels;
using Greenovative.Identity.Infrastructure.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Greenovative.Identity.App.Application.Handlers;

public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, UserViewModel>
{
    private readonly ILogger<RegistrationCommandHandler> logger;
    private readonly IMapper mapper;
    private readonly UserManager<User> userManager;

    public RegistrationCommandHandler(ILogger<RegistrationCommandHandler> logger, IMapper mapper,
                                      UserManager<User> userManager)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.userManager = userManager;
    }

    public async Task<UserViewModel> Handle(RegistrationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var findEmail = await userManager.FindByEmailAsync(request.Users.Email);
            var findUser = request.Users.UserName != null ? await userManager.FindByNameAsync(request.Users.UserName) : null;

            if (findEmail != null)
                throw new DuplicateEmailException("Email already in use. Please register with different email.");
            if (findUser != null)
                throw new DuplicateUserNameException("UserName already in use. Please register with different UserName.");

            var user = mapper.Map<User>(request.Users);
            var result = await userManager.CreateAsync(user, request.Users.Password);
            //var results=await userManager.AddToRoleAsync(user, "Client User");

            if (!result.Succeeded)
                throw new IdentityException(JsonConvert.SerializeObject(result.Errors));

            return mapper.Map<UserViewModel>(user); ;
        }
        catch (Exception ex) {
            return null;
        }
    }
}
public class RegistrationCommand : IRequest<UserViewModel>
{
    public UserViewModel Users { get; set; }

}
