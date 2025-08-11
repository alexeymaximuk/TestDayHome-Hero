using Cysharp.Threading.Tasks;
using R3;
using Scrips.Domain.Hero.HeroSettings;
using UnityEngine;

namespace Scrips.Domain.Wallet.Models
{
    public class HeroWallet : IWalletModel
    {
        public ReactiveProperty<int> CurrentCoins { get; }

        private HeroLevelUpSettings _levelUpSettings;


        public HeroWallet(int initialCoins)
        {
            CurrentCoins = new ReactiveProperty<int>(initialCoins);
        }
        
        public UniTask<bool> TrySpendingAmount(int coinsAmount)
        {
            if (coinsAmount > CurrentCoins.Value) 
                return new UniTask<bool>(false);
            
            CurrentCoins.Value -= coinsAmount;
            return new UniTask<bool>(true);
        }

        public int CalculateLevelUpPriceForLevel(int level)
        {
            var oneLevelUpPrice = Mathf.CeilToInt(_levelUpSettings.RequiredCoinsForLevelUp *
                             _levelUpSettings.CoinsIncreasePerLevelMultiplier * (level - 1));

            return oneLevelUpPrice;
        }
    }
}