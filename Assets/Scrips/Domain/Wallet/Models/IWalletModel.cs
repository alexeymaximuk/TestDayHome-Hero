using Cysharp.Threading.Tasks;
using R3;

namespace Scrips.Domain.Wallet.Models
{
    public interface IWalletModel
    {
        public ReactiveProperty<int> CurrentCoins { get; }
        public UniTask<bool> TrySpendingAmount(int coinsAmount);
        public int CalculateLevelUpPriceForLevel(int level);
    }
}