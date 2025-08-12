using Scrips.Application.UseCases;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using MessagePipe;
using Scrips.Domain.MessagesDTO;
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

            var pipeOptions = builder.RegisterMessagePipe();
            builder.RegisterMessageBroker<LevelUpButtonClickedDTO>(pipeOptions);
            
            builder.RegisterEntryPoint<HeroPresenter>();
            builder.RegisterEntryPoint<HeroUpdateUseCase>();

            builder.RegisterComponent<IHeroView>(_heroLayoutViewBase);
        }
    }
}