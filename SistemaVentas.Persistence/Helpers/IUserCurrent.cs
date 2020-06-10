namespace SistemaVentas.Persistence.Helpers
{
    using Microsoft.AspNetCore.Identity;
    using Model.Auth;

    public interface IUserCurrent
    {
        string GetUserId();
    }
}
