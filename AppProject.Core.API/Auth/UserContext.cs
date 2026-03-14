using System;
using AppProject.Core.Contracts;

namespace AppProject.Core.API.Auth;

public class UserContext : IUserContext
{
    public Task<UserInfo> GetUserAdminUserAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<UserInfo> GetCurrentUserAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
