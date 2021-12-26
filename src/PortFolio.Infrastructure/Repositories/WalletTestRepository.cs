using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using PortFolio.Application.Common.Interfaces.Repositories;
using PortFolio.Domain.Entities;

namespace PortFolio.Infrastructure.Repositories
{
    public class WalletTestRepository : IWalletRepository
    {
        public ICollection<Wallet> _wallets;

        public WalletTestRepository()
        {
            _wallets = new List<Wallet>()
            {
                new Wallet()
                {
                    Id = 1,
                    Name = "MyWallet",
                }
            };
        }
        
        public ICollection<Wallet> Get(Expression<Func<Wallet, bool>> filter)
        {
            return filter is null ? _wallets.ToList() : _wallets.AsQueryable().Where(filter).ToList();
        }

        public int[] Save(IEnumerable<Wallet> dataToSave)
        {
            throw new NotImplementedException();
        }

        public int[] Delete(IEnumerable<Wallet> dataToDelete)
        {
            throw new NotImplementedException();
        }
    }

    public class StockWalletTestRepository : IStockWalletRepository
    {
        private ICollection<StockWallet> _stockWallets;

        public StockWalletTestRepository()
        {
            _stockWallets = new List<StockWallet>()
            {
                new StockWallet()
                {
                    Id = 1,
                    WalletId = 1,
                    StockValueId = 1,
                    Value = 100,
                }
            };
        }
        public ICollection<StockWallet> Get(Expression<Func<StockWallet, bool>> filter)
        {
            return filter is null ? _stockWallets.ToList() : _stockWallets.AsQueryable().Where(filter).ToList();
        }

        public int[] Save(IEnumerable<StockWallet> dataToSave)
        {
            throw new NotImplementedException();
        }

        public int[] Delete(IEnumerable<StockWallet> dataToDelete)
        {
            throw new NotImplementedException();
        }
    }
}