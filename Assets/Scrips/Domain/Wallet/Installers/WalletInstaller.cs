using JetBrains.Annotations;
using Scrips.Application.UseCases;
using Scrips.Domain.Hero.HeroSettings;
using Scrips.Domain.Hero.Models;
using Scrips.Domain.Hero.Presenters;
using Scrips.Domain.Hero.UseCases;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Scrips.Domain.Wallet.Installers
{
    public class WalletInstaller: LifetimeScope
    {
        [SerializeField, NotNull] private HeroLevelUpSettings _levelUpSettings;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<HeroPresenter>();
            builder.Register<HeroModel>(Lifetime.Singleton);
            builder.Register<IHeroUseCase, HeroUpdateUseCase>(Lifetime.Singleton);
        }
    }
}