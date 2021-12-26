using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using PortFolio.Application.Common.Interfaces.Repositories;
using PortFolio.Domain.Entities;

namespace PortFolio.Infrastructure.Repositories
{
    public class StockValueTestRepository : IStockValueRepository
    {
        private IDictionary<(int stockId, int currencyId), StockValue> _stockValues;

        public StockValueTestRepository()
        {
            _stockValues = new Dictionary<(int stockId, int currencyId), StockValue>()
            {
                {(1, 1), new StockValue()
                {
                    Id = 1,
                    CurrencyId = 1,
                    StockId = 1,
                    ValueInCurrency = 500,
                }},
                {(2, 1), new StockValue()
                    {
                        Id = 2,
                        CurrencyId = 1,
                        StockId = 2,
                        ValueInCurrency = 732,
                    } }
            };
        }
        public ICollection<StockValue> Get(Expression<Func<StockValue, bool>> filter)
        {
            return filter is null
                ? _stockValues.Values.ToList()
                : _stockValues.Values.AsQueryable().Where(filter).ToList();
        }

        public int[] Save(IEnumerable<StockValue> dataToSave)
        {
            foreach (var data in dataToSave)
            {
                if (_stockValues.TryGetValue((data.StockId, data.CurrencyId), out var stock))
                {
                    stock.ValueInCurrency = data.ValueInCurrency;
                }
                else
                {
                    _stockValues.Add((data.StockId, data.CurrencyId), data);
                }
            }
            return Array.Empty<int>();
        }

        public int[] Delete(IEnumerable<StockValue> dataToDelete)
        {
            throw new NotImplementedException();
        }
    }
}