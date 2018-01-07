using System;
using System.Collections.Generic;
using System.Linq;
using Traininghub.Data;

namespace traininghub.dac.ef.Common
{
    public class ReadOnlyRepository<T> : IReadOnlyRepository<T> where T: class, IClientEntity
    {
        private readonly IQueryable<T> context;

        public ReadOnlyRepository(IDbDataProvider dataProvider)
        {
            this.context = dataProvider.AsQueryable<T>();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return context.Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return context;
        }

        public T GetById(long id)
        {
            return context.FirstOrDefault(x => x.Id == id);
        }

        public T FirstOrDefault(Func<T, bool> predicate)
        {
            return context.FirstOrDefault(predicate);
        }
    }
}
