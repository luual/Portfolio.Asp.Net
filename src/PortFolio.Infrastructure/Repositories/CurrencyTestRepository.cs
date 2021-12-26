using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using PortFolio.Application.Common.Interfaces.Repositories;
using PortFolio.Domain.Entities;

namespace PortFolio.Infrastructure.Repositories
{
    public class CurrencyTestRepository : ICurrencyRepository
    {
        public ICollection<Currency> Get(Expression<Func<Currency, bool>> filter)
        {
            var values = new[]
            {
                new Currency()
                {
                    Id = 1,
                    Name = "USD",
                },
                new Currency()
                {
                    Id = 2,
                    Name = "EUR",
                },
            }.AsQueryable();
            return filter == null ? values.ToList() : values.Where(filter).ToList();
        }

        public int[] Save(IEnumerable<Currency> dataToSave)
        {
            throw new NotImplementedException();
        }

        public int[] Delete(IEnumerable<Currency> dataToDelete)
        {
            throw new NotImplementedException();
        }
    }
}