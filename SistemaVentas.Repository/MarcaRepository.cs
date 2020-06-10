namespace SistemaVentas.Repository
{
    using Interfaces;
    using Model;
    using Persistence;
    using Repository;

    public interface IMarcaRepository : IPagedRepository<Marca>, IReadRepository<Marca>, ICreateRepository<Marca>, IRemoveRepository<Marca>, IUpdateRepository<Marca>
    {

    }

    public class MarcaRepository : GenericRepository<Marca>, IMarcaRepository
    {
        public MarcaRepository(ApplicationDbContext context)
        {
            Context = context;
        }
    }
}
