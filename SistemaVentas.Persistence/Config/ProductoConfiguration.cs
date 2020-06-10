namespace SistemaVentas.Persistence.Config
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Model;

    public class ProductoConfiguration
    {
        public ProductoConfiguration(EntityTypeBuilder<Producto> entityBuilder)
        {
            entityBuilder.HasKey(e => e.pkProducto);
            entityBuilder.Property(e => e.cProducto).HasMaxLength(250).IsRequired();
            entityBuilder
                .HasOne(e => e.Modelo)
                .WithMany()
                .HasForeignKey(e => e.fkModelo);

        }
    }
}
