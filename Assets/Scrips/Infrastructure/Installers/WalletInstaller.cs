using Scrips.Domain.Models.Wallet;
using Scrips.Presentation.Presenters;
using Scrips.Presentation.Views.WalletView;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Scrips.Infrastructure.Installers
{
    public class WalletInstaller: LifetimeScope
    {
        
        [SerializeField] private WalletWidget _walletLayout;
        [SerializeField] private int _initialCoins = 100000;

        protected override void Configure(IContainerBuilder builder)
        {
            var wallet = new WalletModel(_initialCoins);
            
            builder.RegisterInstance<IWalletModel>(wallet);
            builder.RegisterInstance<IWalletWidget>(_walletLayout);

            builder.RegisterEntryPoint<WalletPresenter>();
        }
    }
}