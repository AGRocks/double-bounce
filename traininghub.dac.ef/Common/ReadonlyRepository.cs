using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Traininghub.Data;

namespace traininghub.dac.ef.Common
{
    public class ReadonlyRepository<T> : IReadOnlyRepository<T> where T: class, IClientEntity
    {
        private IQueryable<T> context;

        public ReadonlyRepository(IDbDataProvider dataProvider)
        {
            this.context = dataProvider.GetDbSet<T>().AsQueryable();
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
