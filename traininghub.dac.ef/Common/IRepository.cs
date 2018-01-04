using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Traininghub.Data;

namespace traininghub.dac.ef.Common
{
    public interface IRepository<T> : IReadOnlyRepository<T> where T: class, IClientEntity
    {
        void Insert(T entity);
        void Delete(T entity);
        void Attach(T entity);        
    }
}
