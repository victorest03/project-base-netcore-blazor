namespace SistemaVentas.Persistence.Config
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Model;

    public class ClienteConfiguration
    {
        public ClienteConfiguration(EntityTypeBuilder<Cliente> entityBuilder)
        {
            entityBuilder.HasKey(e => e.pkCliente);
            entityBuilder.Property(e => e.cNombre).HasMaxLength(250);
        }
    }
}
