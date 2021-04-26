using System.Threading.Tasks;

namespace RealEstateAgency.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
