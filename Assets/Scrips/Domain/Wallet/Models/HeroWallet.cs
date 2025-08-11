using Cysharp.Threading.Tasks;
using R3;
using Scrips.Domain.Hero.Configs;
using UnityEngine;

namespace Scrips.Domain.Wallet.Models
{
    public class HeroWallet : IWalletModel
    {
        public ReactiveProperty<long> CurrentCoins { get; }

        private readonly HeroLevelUpSettings _levelUpSettings;
        
        public HeroWallet(int initialCoins, HeroLevelUpSettings levelUpSettings)
        {
            CurrentCoins = new ReactiveProperty<long>(initialCoins);
            _levelUpSettings = levelUpSettings;
        }
        
        public bool TrySpendingAmount(long coinsAmount)
        {
            if (coinsAmount > CurrentCoins.Value) 
                return false;
            
            CurrentCoins.Value -= coinsAmount;
            return true;
        }

        public long CalculateLevelUpPriceForLevel(int level)
        {
            var oneLevelUpPrice = (long)(_levelUpSettings.RequiredCoinsForLevelUp *
                             Mathf.Pow(_levelUpSettings.CoinsIncreasePerLevelMultiplier, level - 1));

            return oneLevelUpPrice;
        }
    }
}