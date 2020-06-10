namespace SistemaVentas.UnitOfWork.Interfaces
{
    using Repository;

    public interface IUnitOfWorkRepository
    {
        IProductoRepository ProductoRepository { get; }
        IMarcaRepository MarcaRepository { get; }
        IClienteRepository ClienteRepository { get; }
    }
}
