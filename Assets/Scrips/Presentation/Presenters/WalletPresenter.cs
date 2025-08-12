using System;
using R3;
using Scrips.Domain.Models.Wallet;
using Scrips.Presentation.Views;
using Scrips.Presentation.Views.WalletView;
using VContainer;
using VContainer.Unity;

namespace Scrips.Presentation.Presenters
{
    public class WalletPresenter : IStartable, IDisposable
    {
        [Inject] private readonly IWalletModel _walletModel;
        [Inject] private readonly IWalletWidget _view;
        
        private readonly CompositeDisposable _compositeDisposable = new ();
        
        public void Start()
        {
            _walletModel.CurrentCoins.Subscribe(UpdateCurrentCoins).AddTo(_compositeDisposable);
        }
        
        public void Dispose()
        {
            _compositeDisposable.Dispose();
        }

        private void UpdateCurrentCoins(long coins)
        {
            _view.UpdateCoinsStats(coins);
        }

    }
}