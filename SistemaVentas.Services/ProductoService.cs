namespace SistemaVentas.Services
{
    using Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using UnitOfWork.Interfaces;

    public interface IProductoService
    {
        Task<IEnumerable<Producto>> GetAllAsync();
        Task<int> AddAsync(Producto model);
        Task<Producto> Get(int id);
        void Delete(int id);
    }

    public class ProductoService : IProductoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            return await _unitOfWork.Repository.ProductoRepository.GetAllAsync();
        }

        public async Task<int> AddAsync(Producto model)
        {
            await _unitOfWork.Repository.ProductoRepository.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();

            return model.pkProducto;
        }

        public async Task<Producto> Get(int id)
        {
            return await _unitOfWork.Repository.ProductoRepository.FirstOrDefaultAsync(producto => producto.pkProducto == id);
        }

        public void Delete(int id)
        {
            _unitOfWork.Repository.ProductoRepository.Remove(producto => producto.pkProducto == id);
            _unitOfWork.SaveChangesAsync();
        }
    }
}
