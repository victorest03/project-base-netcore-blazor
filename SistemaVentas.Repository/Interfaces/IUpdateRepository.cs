namespace SistemaVentas.Repository.Interfaces
{
    using System.Collections.Generic;

    public interface IUpdateRepository<T> where T : class
    {
        void Update(T t);
        void Update(IEnumerable<T> t);
    }
}
