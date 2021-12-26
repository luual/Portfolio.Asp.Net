using NUnit.Framework;
using PortFolio.Application.Queries;
using PortFolio.Infrastructure.Repositories;

namespace PortFolio.Application.Tests.StockValues
{
    [TestFixture]
    public class GetStockValuesTests
    {
        [Test]
        public void GetStockValues()
        {
            // Arrange
            var command = new GetStockValuesQuery();
            var handler = new GetStockValuesQueryHandler(new StockValueTestRepository(), new CurrencyTestRepository(),
                new StockTestRepository());
            
            // Act
            var stocksValues = handler.Handle(command, default).Result;

            // Assert
            Assert.IsTrue(stocksValues.Count > 0);
        }
    }
}