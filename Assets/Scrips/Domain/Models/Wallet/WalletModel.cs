using R3;
using Scrips.Infrastructure.Configs;
using UnityEngine;

namespace Scrips.Domain.Models.Wallet
{
    public class WalletModel : IWalletModel
    {
        public ReactiveProperty<long> CurrentCoins { get; }
        
        public WalletModel(int initialCoins)
        {
            CurrentCoins = new ReactiveProperty<long>(initialCoins);
        }
        
        public bool TrySpendingAmount(long coinsAmount)
        {
            if (coinsAmount > CurrentCoins.Value) 
                return false;
            
            CurrentCoins.Value -= coinsAmount;
            return true;
        }
    }
}