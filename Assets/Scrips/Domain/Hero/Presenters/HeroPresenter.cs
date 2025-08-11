using System;
using R3;
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

        private CompositeDisposable _compositeDisposable;
        
        [Inject]
        public HeroPresenter(IHeroStatsModel heroStatsModel, IWalletModel walletModel, IHeroView view)
        {
            _walletModel = walletModel;
            _heroStatsModel = heroStatsModel;
            _view = view;
        }
        
        public void Start()
        {
            _compositeDisposable = new CompositeDisposable();
            _heroStatsModel.CurrentStats.Subscribe(_ => UpdateHeroView()).AddTo(_compositeDisposable);
            _walletModel.CurrentCoins.Subscribe(_ => UpdateCoinsValue()).AddTo(_compositeDisposable);
        }
        
        public void Dispose()
        {   
            _compositeDisposable.Dispose();
        }


        private void UpdateHeroView()
        {
            var currentLevel = _heroStatsModel.CurrentLevel();
            
            _view.UpdateHeroStats(currentLevel, 
                _walletModel.CalculateLevelUpPriceForLevel(currentLevel + 1),
                _heroStatsModel.CurrentStats.Value);
        }

        private void UpdateCoinsValue()
        {
            _view.UpdateCoinsStats(_walletModel.CurrentCoins.Value);
        }
    }
}