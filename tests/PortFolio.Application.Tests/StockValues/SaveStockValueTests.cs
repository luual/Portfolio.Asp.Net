using System.Linq;
using NUnit.Framework;
using PortFolio.Application.Commands;
using PortFolio.Application.Queries;
using PortFolio.Infrastructure.Repositories;

namespace PortFolio.Application.Tests.StockValues
{
    [TestFixture]
    public class SaveStockValueTests
    {
        [Test]
        public void SaveStockValue_Add_Single_Element()
        {
            // Create a new StockValue Apple EUR at 123 price
            // Arrange
            var command = new SaveStockValueCommand(2, 1, 123);
            var stockValueTestRepository = new StockValueTestRepository();
            var handler = new SaveStockValuesCommandHandler(stockValueTestRepository);
            var getCommand = new GetStockValuesQuery(x => x.CurrencyId == 2 && x.StockId == 1);
            var stockTestRepository = new StockTestRepository();
            var currencyTestRepository = new CurrencyTestRepository();
            var getHandler = new GetStockValuesQueryHandler(stockValueTestRepository,
                currencyTestRepository, stockTestRepository);
            // Act
            var r = handler.Handle(command, default).Result;
            var stockValue = getHandler.Handle(getCommand, default).Result.Single();
            
            // Assert
            Assert.AreEqual("Apple", stockValue.Stock);
            Assert.AreEqual("EUR", stockValue.Currency);
            Assert.AreEqual(123, stockValue.ValueInCurrency);
        }
        
        [Test]
        public void UpdateStockValue_Update_Single_Element()
        {
            // Create a new StockValue Apple EUR at 123 price
            // Arrange
            var command = new SaveStockValueCommand(1, 1, 123);
            var stockValueTestRepository = new StockValueTestRepository();
            var handler = new SaveStockValuesCommandHandler(stockValueTestRepository);
            var getCommand = new GetStockValuesQuery(x => x.CurrencyId == 1 && x.StockId == 1);
            var stockTestRepository = new StockTestRepository();
            var currencyTestRepository = new CurrencyTestRepository();
            var getHandler = new GetStockValuesQueryHandler(stockValueTestRepository,
                currencyTestRepository, stockTestRepository);
            // Act
            var stockValue = getHandler.Handle(getCommand, default).Result.Single();
            Assert.AreEqual("Apple", stockValue.Stock);
            Assert.AreEqual("USD", stockValue.Currency);
            Assert.AreEqual(500, stockValue.ValueInCurrency);
            var r = handler.Handle(command, default).Result;
             stockValue = getHandler.Handle(getCommand, default).Result.Single();
            
            // Assert
            Assert.AreEqual("Apple", stockValue.Stock);
            Assert.AreEqual("USD", stockValue.Currency);
            Assert.AreEqual(123, stockValue.ValueInCurrency);
        }
    }
}