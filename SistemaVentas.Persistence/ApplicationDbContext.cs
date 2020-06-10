namespace SistemaVentas.Persistence
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Config;
    using Helpers;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Model;
    using Model.Auth;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,string>
    {
        private readonly IUserCurrent _userCurrent;
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public ApplicationDbContext(DbContextOptions options, IUserCurrent userCurrent) : base(options)
        {
            _userCurrent = userCurrent;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = new ApplicationUserConfiguration(modelBuilder.Entity<ApplicationUser>());
            _ = new MarcaConfiguration(modelBuilder.Entity<Marca>());
            _ = new ModeloConfiguration(modelBuilder.Entity<Modelo>());
            _ = new ProductoConfiguration(modelBuilder.Entity<Producto>());
            _ = new ClienteConfiguration(modelBuilder.Entity<Cliente>());
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.DisplayName());
            }
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var dateTimeNow = DateTimeOffset.Now;
            foreach (var entityEntry in ChangeTracker.Entries().Where(e=>e.Entity is BaseModel))
            {
                if (!(entityEntry.Entity is BaseModel entity)) continue;
                switch (entityEntry.State)
                {
                    case EntityState.Added:
                        entity.fFechaCrea = dateTimeNow;
                        entity.fkUsuarioCrea = _userCurrent.GetUserId();
                        break;
                    case EntityState.Modified:
                        entity.fFechaEdita = dateTimeNow;
                        entity.fkUsuarioEdita = _userCurrent.GetUserId();
                        entityEntry.Property(nameof(entity.fFechaCrea)).IsModified = false;
                        entityEntry.Property(nameof(entity.fkUsuarioCrea)).IsModified = false;
                        break;
                    case EntityState.Deleted:
                        if (entity is BaseModelDeleted entityDeleted)
                        {
                            entityDeleted.fFechaEdita = dateTimeNow;
                            entityDeleted.fkUsuarioEdita = _userCurrent.GetUserId();
                            entityDeleted.isDeleted = true;
                            entityEntry.Property(nameof(entityDeleted.fFechaCrea)).IsModified = false;
                            entityEntry.Property(nameof(entityDeleted.fkUsuarioCrea)).IsModified = false;
                            entityEntry.State = EntityState.Modified;
                        }
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }

}
