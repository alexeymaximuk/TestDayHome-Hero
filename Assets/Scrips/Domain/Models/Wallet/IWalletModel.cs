using R3;

namespace Scrips.Domain.Models.Wallet
{
    public interface IWalletModel
    {
        public ReactiveProperty<long> CurrentCoins { get; }
        public bool TrySpendingAmount(long coinsAmount);
    }
}