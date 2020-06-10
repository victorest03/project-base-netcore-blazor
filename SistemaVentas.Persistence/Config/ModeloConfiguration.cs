namespace SistemaVentas.Persistence.Config
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Model;

    public class ModeloConfiguration
    {
        public ModeloConfiguration(EntityTypeBuilder<Modelo> entityBuilder)
        {
            entityBuilder.HasKey(e => e.pkModelo);
            entityBuilder.Property(e => e.cModelo).HasMaxLength(250);
            entityBuilder
                .HasOne(e => e.Marca)
                .WithMany()
                .HasForeignKey(e => e.fkMarca);
            
        }
    }
}
