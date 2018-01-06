using System.Linq;
using Traininghub.Data;

namespace traininghub.dac.ef.Common
{
    public interface IDbDataProvider
    {
        IQueryable<T> AsQueryable<T>() where T : class, IClientEntity;
    }
}