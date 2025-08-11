using JetBrains.Annotations;
using Scrips.Domain.Hero.Configs;
using Scrips.Domain.Wallet.Models;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Scrips.Infrastructure.Installers
{
    public class WalletInstaller: LifetimeScope
    {
        [SerializeField] private int _initialCoins = 100000;
        [SerializeField] private HeroLevelUpSettings _levelUpSettings;

        protected override void Configure(IContainerBuilder builder)
        {
            var wallet = new HeroWallet(_initialCoins, _levelUpSettings);
            builder.RegisterInstance<IWalletModel>(wallet);
        }
    }
}