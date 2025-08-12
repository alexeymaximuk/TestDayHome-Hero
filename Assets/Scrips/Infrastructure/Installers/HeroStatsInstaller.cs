using MessagePipe;
using Scrips.Domain.MessagesDTO;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Scrips.Presentation.Presenters;
using Scrips.Presentation.Views.HeroStatsView;

namespace Scrips.Infrastructure.Installers
{
    public class HeroStatsInstaller : LifetimeScope
    {
        [SerializeField] private HeroStatsLayoutViewBase _heroStatsLayoutViewBase;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<HeroStatsPresenter>();
            builder.RegisterComponent<IHeroStatsView>(_heroStatsLayoutViewBase);
        }
    }
}