namespace SistemaVentas.Repository
{
    using Interfaces;
    using Model;
    using Persistence;
    using Repository;

    public interface IProductoRepository : IPagedRepository<Producto>, IReadRepository<Producto>, ICreateRepository<Producto>, IRemoveRepository<Producto>, IUpdateRepository<Producto>
    {

    }

    public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
    {
        public ProductoRepository(ApplicationDbContext context)
        {
            Context = context;
        }
    }
}
