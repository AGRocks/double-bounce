using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traininghub.Data;

namespace traininghub.dac.ef.Common
{
    public class Repository<T> : IRepository<T> where T : class, IClientEntity
    {
        private IDbSet<T> context;
        private IUnitOfWork unitOfWork;
        private IDbDataProvider dataProvider;

        public Repository(IDbDataProvider dataProvider)
        {
            this.context = dataProvider.GetDbSet<T>();
            this.dataProvider = dataProvider;
            unitOfWork = dataProvider as IUnitOfWork;
        }

        public void Insert(T entity)
        {
            context.Add(entity);
        }

        public void Delete(T entity)
        {
            context.Remove(entity);
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

        public void Attach(T entity)
        {
            this.context.Attach(entity);
        }
        #region IUnitOfWork Members

        public void Save()
        {
            if (unitOfWork != null)
                unitOfWork.Save();
        }

        public Task SaveAsync()
        {
            if (unitOfWork != null)
                return unitOfWork.SaveAsync();

            return Task.Delay(0);
        }

        #endregion
    }
}