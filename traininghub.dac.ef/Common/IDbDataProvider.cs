using Microsoft.EntityFrameworkCore;
using System.Linq;
using Traininghub.Data;

namespace traininghub.dac.ef.Common
{
    public interface IDbDataProvider : IUnitOfWork
    {
        IQueryable<T> AsQueryable<T>() where T : class, IClientEntity;
        DbSet<T> GetDbSet<T>() where T : class, IClientEntity;
    }
}