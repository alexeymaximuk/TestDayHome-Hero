using Scrips.Application.UseCases;
using Scrips.Domain.Hero.Models;
using Scrips.Domain.Hero.Presenters;
using Scrips.Presentation.Views;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using MessagePipe;
using Scrips.Domain.Hero.Configs;
using Scrips.Domain.Hero.MessagesDTO;

namespace Scrips.Infrastructure.Installers
{
    public class HeroInstaller : LifetimeScope
    {
        [SerializeField] private HeroView _heroView;
        [SerializeField] private HeroStartingStatsSettings _heroStartingSettings;

        protected override void Configure(IContainerBuilder builder)
        {
            var heroModel = new HeroModel(_heroStartingSettings);
            
            builder.RegisterInstance<IHeroStatsModel, IHeroUpdatableModel>(heroModel);

            var pipeOptions = builder.RegisterMessagePipe();
            builder.RegisterMessageBroker<LevelUpButtonClickedDTO>(pipeOptions);
            
            
            builder.RegisterEntryPoint<HeroPresenter>();
            builder.RegisterEntryPoint<HeroUpdateUseCase>();

            builder.RegisterComponent<IHeroView>(_heroView);
        }
    }
}