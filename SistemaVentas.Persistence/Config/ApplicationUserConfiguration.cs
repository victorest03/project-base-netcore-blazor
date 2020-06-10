namespace SistemaVentas.Persistence.Config
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Model.Auth;

    public class ApplicationUserConfiguration
    {
        public ApplicationUserConfiguration(EntityTypeBuilder<ApplicationUser> entityBuilder)
        {
            entityBuilder.Ignore(e => e.cFullName);
        }
    }
}
