using System;
using System.Collections.Generic;
using Traininghub.Data;

namespace traininghub.dac.ef.Common
{
    public interface IReadOnlyRepository<T> where T: class, IClientEntity
    {
        IEnumerable<T> Find(Func<T, bool> predicate);
        IEnumerable<T> GetAll();
        T GetById(long id);
        T FirstOrDefault(Func<T, bool> predicate);
    }
}