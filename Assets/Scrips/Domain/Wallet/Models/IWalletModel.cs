using Cysharp.Threading.Tasks;
using R3;

namespace Scrips.Domain.Wallet.Models
{
    public interface IWalletModel
    {
        public ReactiveProperty<long> CurrentCoins { get; }
        public bool TrySpendingAmount(long coinsAmount);
        public long CalculateLevelUpPriceForLevel(int level);
    }
}