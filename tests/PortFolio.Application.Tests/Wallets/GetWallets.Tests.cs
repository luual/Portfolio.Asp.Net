using System.Linq;
using NUnit.Framework;
using PortFolio.Application.Queries;
using PortFolio.Infrastructure.Repositories;

namespace PortFolio.Application.Tests.Wallets
{
    [TestFixture]
    public class GetWallets_Tests
    {
        [Test]
        public void GetWallets_With_SingleWallets()
        {
            // Arrange
            var command = new GetWalletsQuery();
            var handler = new GetWalletsQueryHandler(new WalletTestRepository(), new CurrencyTestRepository(),
                new StockTestRepository(),
                new StockWalletTestRepository(),
                new StockValueTestRepository());
            
            // Assert
            var wallet = handler.Handle(command, default).Result.Single();
            
            // Act
            Assert.AreEqual("MyWallet",wallet.WalletName);
            Assert.AreEqual(1, wallet.Assets.Count);
            var asset = wallet.Assets.Stocks.Single();
            Assert.AreEqual("Apple", asset.AssetName);
            Assert.AreEqual("USD", asset.Currency);
            Assert.AreEqual(100, asset.Value);
        }
    }
}