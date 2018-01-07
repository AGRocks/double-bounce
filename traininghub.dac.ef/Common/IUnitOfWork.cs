using System.Threading.Tasks;

namespace traininghub.dac.ef.Common
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
        void Save();
    }
}