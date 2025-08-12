using System;
using System.Collections.Generic;
using MessagePipe;
using R3;
using Scrips.Domain.MessagesDTO;
using Scrips.Domain.Models.Hero;
using Scrips.Domain.Models.HeroStats;
using Scrips.Presentation.Views.HeroView;
using VContainer;
using VContainer.Unity;
using CompositeDisposable = R3.CompositeDisposable;

namespace Scrips.Presentation.Presenters
{
    public class HeroPresenter : IStartable, IDisposable
    {
        [Inject] private readonly IHeroStatsModel _heroStatsModel;
        [Inject] private readonly IHeroUpdatableModel _heroUpdatableModel;
        [Inject] private readonly IHeroView _view;
        [Inject] private readonly IPublisher<LevelUpButtonClickedDTO> _publisher;
        
        private CompositeDisposable _compositeDisposable;

        public void Start()
        {
            _compositeDisposable = new CompositeDisposable();
            
            _heroStatsModel.CurrentLevel.Subscribe(UpdateHeroLevel).AddTo(_compositeDisposable);
            _heroStatsModel.CurrentStats.Subscribe(UpdateHeroStats).AddTo(_compositeDisposable);
            _heroUpdatableModel.NextLevelPrice.Subscribe(UpdateHeroLevelUpPrice).AddTo(_compositeDisposable);
            
            _view.AddOnButtonClickedAction(OnLevelUpClicked);
        }
        
        public void Dispose()
        {   
            _view.RemoveOnButtonClickedAction(OnLevelUpClicked);
            _compositeDisposable.Dispose();
        }

        private void OnLevelUpClicked()
        {
            _publisher.Publish(new LevelUpButtonClickedDTO(_heroStatsModel.CurrentLevel.CurrentValue));
        }

        private void UpdateHeroLevelUpPrice(long levelUpPrice)
        {
            _view.UpdateLevelUpPrice(levelUpPrice);
        }
        
        private void UpdateHeroLevel(int currentLevel)
        {
            _view.UpdateHeroLevel(currentLevel);
        }
        
        private void UpdateHeroStats(IReadOnlyList<ICharacterStatData> characterStats)
        {
            _view.UpdateHeroStats(characterStats);
        }
    }
}