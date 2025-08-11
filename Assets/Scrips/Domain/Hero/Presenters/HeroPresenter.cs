using System;
using MessagePipe;
using R3;
using Scrips.Domain.Hero.MessagesDTO;
using Scrips.Domain.Hero.Models;
using Scrips.Domain.Wallet.Models;
using Scrips.Presentation.Views;
using VContainer;
using VContainer.Unity;
using CompositeDisposable = R3.CompositeDisposable;

namespace Scrips.Domain.Hero.Presenters
{
    public class HeroPresenter : IStartable, IDisposable
    {
        private readonly IHeroStatsModel _heroStatsModel;
        private readonly IHeroView _view;
        private readonly IWalletModel _walletModel;
        private readonly IPublisher<LevelUpButtonClickedDTO> _publisher;
        private CompositeDisposable _compositeDisposable;

        [Inject]
        public HeroPresenter(IHeroStatsModel heroStatsModel, IWalletModel walletModel, IHeroView view,
            IPublisher<LevelUpButtonClickedDTO> publisher)
        {
            _walletModel = walletModel;
            _heroStatsModel = heroStatsModel;
            _view = view;
            _publisher = publisher;
        }

        public void Start()
        {
            _compositeDisposable = new CompositeDisposable();
            _heroStatsModel.CurrentStats.Subscribe(_ => UpdateHeroView()).AddTo(_compositeDisposable);
            _walletModel.CurrentCoins.Subscribe(_ => UpdateCoinsValue()).AddTo(_compositeDisposable);
            
            _view.AddOnButtonClickedAction(OnLevelUpClicked);
        }
        
        public void Dispose()
        {   
            _view.RemoveOnButtonClickedAction(OnLevelUpClicked);
            _compositeDisposable.Dispose();
        }

        private void OnLevelUpClicked()
        {
            _publisher.Publish(new LevelUpButtonClickedDTO(_heroStatsModel.CurrentLevel()));
        }
        
        private void UpdateHeroView()
        {
            var currentLevel = _heroStatsModel.CurrentLevel();
            
            _view.UpdateHeroStats(currentLevel, 
                _walletModel.CalculateLevelUpPriceForLevel(currentLevel),
                _heroStatsModel.CurrentStats.CurrentValue);
        }

        private void UpdateCoinsValue()
        {
            _view.UpdateCoinsStats(_walletModel.CurrentCoins.CurrentValue);
        }
    }
}