using System.Threading.Tasks;

namespace traininghub.dac.ef.Common
{
    internal interface IUnitOfWork
    {
        Task SaveAsync();
        void Save();
    }
}