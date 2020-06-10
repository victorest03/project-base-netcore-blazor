namespace SistemaVentas.Services.Auth
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;
    using Model.Auth;
    using System.Collections.Generic;

    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole> store, IEnumerable<IRoleValidator<ApplicationRole>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<ApplicationRole>> logger) : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }
    }
}
