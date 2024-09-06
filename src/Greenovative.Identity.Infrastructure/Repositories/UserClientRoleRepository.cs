﻿using Greenovative.Accounting.Framework.Data;
using Greenovative.Identity.Infrastructure.ClientModels;

namespace Greenovative.Identity.Infrastructure.Repositories;

public class UserClientRoleRepository : Repository<UserClientRole, ApplicationIdentityDbContext>, IUserClientRoleRepository
{
    public UserClientRoleRepository(ApplicationIdentityDbContext context) : base(context)
    {
    }

}
