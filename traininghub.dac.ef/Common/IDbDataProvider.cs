using System.Data.Entity;
using Traininghub.Data;

namespace traininghub.dac.ef.Common
{
    public interface IDbDataProvider
    {
        IDbSet<T> GetDbSet<T>() where T : class, IClientEntity;
    }
}