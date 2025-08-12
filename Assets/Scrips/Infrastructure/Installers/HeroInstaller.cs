using System;
using Scrips.Application.UseCases;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Scrips.Domain.Models.Hero;
using Scrips.Infrastructure.Configs;
using Scrips.Presentation.Presenters;
using Scrips.Presentation.Views.HeroView;

namespace Scrips.Infrastructure.Installers
{
    public class HeroInstaller : LifetimeScope
    {
        [SerializeField] private HeroLayoutViewBase _heroLayoutViewBase;
        [SerializeField] private HeroStartingStatsSettings _heroStartingSettings;
        [SerializeField] private HeroLevelUpSettings _heroLevelUpSettings;

        protected override void Configure(IContainerBuilder builder)
        {
            var heroModel = new HeroModel(_heroStartingSettings, _heroLevelUpSettings);
            
            builder.RegisterInstance<IHeroStatsModel, IHeroUpdatableModel>(heroModel);
            
            builder.RegisterEntryPoint<HeroPresenter>();
            
            builder.Register<HeroUpdateUseCase>(Lifetime.Singleton).As<IInitializable>().As<IDisposable>();
            builder.Register<StatSelectUseCase>(Lifetime.Singleton).As<IInitializable>().As<IDisposable>();

            builder.RegisterComponent<IHeroView>(_heroLayoutViewBase);
        }
    }
}