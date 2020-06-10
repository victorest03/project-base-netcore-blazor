namespace SistemaVentas.Repository
{
    using Interfaces;
    using Model;
    using Persistence;
    using Repository;

    public interface IClienteRepository : IPagedRepository<Cliente>, IReadRepository<Cliente>, ICreateRepository<Cliente>, IRemoveRepository<Cliente>, IUpdateRepository<Cliente>
    {

    }

    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext context)
        {
            Context = context;
        }
    }
}
