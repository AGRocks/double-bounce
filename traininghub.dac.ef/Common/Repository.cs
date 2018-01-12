using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Traininghub.Data;

namespace traininghub.dac.ef.Common
{
    public class Repository<T> : IRepository<T> where T: class, IClientEntity
    {
        private readonly DbSet<T> context;
        private readonly IUnitOfWork unitOfWork;

        public Repository(IDbDataProvider dataProvider)
        {
            this.context = dataProvider.GetDbSet<T>();
            this.unitOfWork = dataProvider;
        }

        public void Attach(T entity)
        {
            this.context.Attach(entity);
        }

        public void Delete(int id)
        {
            var entity = this.GetById(id);
            this.context.Remove(entity);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return this.context.Where(predicate);
        }

        public T FirstOrDefault(Func<T, bool> predicate)
        {
            return this.context.FirstOrDefault(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return this.context;
        }

        public T GetById(long id)
        {
            return this.context.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(T entity)
        {
            this.context.Add(entity);
        }

        public void Save()
        {
            this.unitOfWork.Save();
        }

        public Task SaveAsync()
        {
            return this.unitOfWork.SaveAsync();
        }
    }
}
