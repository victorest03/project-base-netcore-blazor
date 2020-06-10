namespace SistemaVentas.Frontend.Helper
{
    using Microsoft.AspNetCore.Http;
    using Persistence.Helpers;
    using System;
    using System.Security.Claims;

    public class UserCurrent : IUserCurrent
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserCurrent(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new NotImplementedException();
        }

        public string GetUserId()
        {
            var claimsIdentity = (ClaimsIdentity)_httpContextAccessor.HttpContext.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim?.Value;
            return userId;
        }
    }
}
