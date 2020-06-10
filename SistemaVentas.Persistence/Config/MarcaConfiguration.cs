namespace SistemaVentas.Persistence.Config
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Model;

    public class MarcaConfiguration
    {
        public MarcaConfiguration(EntityTypeBuilder<Marca> entityBuilder)
        {
            entityBuilder.HasKey(e => e.pkMarca);
            entityBuilder.Property(e => e.cMarca).HasMaxLength(250);
        }
    }
}
