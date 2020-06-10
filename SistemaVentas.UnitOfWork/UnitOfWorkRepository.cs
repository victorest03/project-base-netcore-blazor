namespace SistemaVentas.UnitOfWork
{
    using Interfaces;
    using Persistence;
    using Repository;

    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public IProductoRepository ProductoRepository { get; }
        public IMarcaRepository MarcaRepository { get; }
        public IClienteRepository ClienteRepository { get; }

        public UnitOfWorkRepository(ApplicationDbContext context)
        {
            ProductoRepository = new ProductoRepository(context);
            MarcaRepository = new MarcaRepository(context);
            ClienteRepository = new ClienteRepository(context);
        }
    }
}
