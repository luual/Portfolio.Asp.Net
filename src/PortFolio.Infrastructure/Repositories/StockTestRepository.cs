using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using PortFolio.Application.Common.Interfaces.Repositories;
using PortFolio.Domain.Entities;

namespace PortFolio.Infrastructure.Repositories
{
    public class StockTestRepository : IStockRepository
    {
        private ICollection<Stock> _stocks;


        public StockTestRepository()
        {
            _stocks = new List<Stock>()
            {
                new Stock()
                {
                    Id = 1,
                    Name = "Apple",
                },
                new Stock()
                {
                    Id = 2,
                    Name = "Microsoft",
                }
            };
        }
        public ICollection<Stock> Get(Expression<Func<Stock, bool>> filter)
        {
            return filter is null ? _stocks.ToList() : _stocks.AsQueryable().Where(filter).ToList();
        }

        public int[] Save(IEnumerable<Stock> dataToSave)
        {
            throw new NotImplementedException();
        }

        public int[] Delete(IEnumerable<Stock> dataToDelete)
        {
            throw new NotImplementedException();
        }
    }
}