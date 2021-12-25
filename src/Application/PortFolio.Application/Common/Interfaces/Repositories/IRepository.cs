using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PortFolio.Application.Common.Interfaces.Repositories;

public interface IRepository<T>
{
    ICollection<T> Get(Expression<Func<T, bool>> filter);
    int[] Save(IEnumerable<T> dataToSave);
    int[] Delete(IEnumerable<T> dataToDelete);
}

