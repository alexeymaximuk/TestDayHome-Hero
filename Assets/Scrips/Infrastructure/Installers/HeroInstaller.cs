using Scrips.Application.UseCases;
using Scrips.Domain.Hero.HeroSettings;
using Scrips.Domain.Hero.Models;
using Scrips.Domain.Hero.Presenters;
using Scrips.Domain.Hero.UseCases;
using Scrips.Presentation.Views;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Scrips.Infrastructure.Installers
{
    public class HeroInstaller : LifetimeScope
    {
        [SerializeField] private HeroView _heroView;
        [SerializeField] private HeroStartingStatsSettings _heroStartingSettings;

        protected override void Configure(IContainerBuilder builder)
        {
            var heroModel = new HeroModel(_heroStartingSettings);
            builder.RegisterInstance<IHeroStatsModel>(heroModel);
            builder.RegisterInstance<IHeroUpdatableModel>(heroModel);
            
            builder.RegisterEntryPoint<HeroPresenter>();
            builder.Register<HeroModel>(Lifetime.Singleton);
            builder.Register<IHeroUseCase, HeroUpdateUseCase>(Lifetime.Singleton);

            builder.RegisterComponent(_heroView);
        }
    }
}