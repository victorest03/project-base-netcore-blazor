namespace SistemaVentas.UnitOfWork.Interfaces
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore.Storage;

    public interface IUnitOfWork
    {
        void DetectChanges();
        void SaveChanges();
        Task SaveChangesAsync();
        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
        void CommitTransaction();
        void RollbackTransaction();

        IUnitOfWorkRepository Repository { get; }
    }
}
