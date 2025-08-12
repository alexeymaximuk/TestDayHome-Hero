using UnityEngine;
using VContainer;
using VContainer.Unity;
using MessagePipe;
using Scrips.Domain.MessagesDTO;
using Scrips.Presentation.Presenters;
using Scrips.Presentation.Views.HeroStatsView;
using Scrips.Presentation.Views.HeroView;

namespace Scrips.Infrastructure.Installers
{
    public class HeroStatsInstaller : LifetimeScope
    {
        [SerializeField] private HeroStatsLayoutViewBase _heroStatsLayoutViewBase;

        protected override void Configure(IContainerBuilder builder)
        {
            var pipeOptions = builder.RegisterMessagePipe();
            builder.RegisterMessageBroker<LevelUpButtonClickedDTO>(pipeOptions);
            
            builder.RegisterEntryPoint<HeroStatsPresenter>();
            builder.RegisterComponent<IHeroStatsView>(_heroStatsLayoutViewBase);
        }
    }
}