using System;
using MessagePipe;
using R3;
using Scrips.Domain.MessagesDTO;
using Scrips.Domain.Models.Hero;
using Scrips.Domain.Models.Wallet;
using VContainer;
using VContainer.Unity;

namespace Scrips.Application.UseCases
{
    public class HeroUpdateUseCase : IInitializable, IDisposable
    {
        [Inject] private readonly IHeroUpdatableModel _updatableModelHero;
        [Inject] private readonly IWalletModel _walletModel;
        [Inject] private readonly ISubscriber<LevelUpButtonClickedDTO> _levelUpButtonSubscriber;
        [Inject] private readonly ISubscriber<OnHeroStatSelectedDTO> _statSelectedSubscriber;
        
        private CompositeDisposable _subscriptions = new CompositeDisposable();
        private string _currentSelectedStatId;
        public void Initialize()
        {
            _statSelectedSubscriber.Subscribe( statSelectedMessage =>
            {
                _currentSelectedStatId = statSelectedMessage.StatId;
            }).AddTo(_subscriptions);
            
            _levelUpButtonSubscriber.Subscribe( buttonClickedData =>
            {
                if (_currentSelectedStatId == null)
                {
                    //button should be disabled unless user selects stat first
                    return;
                }
                
                var coinsForNextLevel = _updatableModelHero.NextLevelPrice.CurrentValue;
                var wasPurchaseCompleted = _walletModel.TrySpendingAmount(coinsForNextLevel);

                if (wasPurchaseCompleted)
                    _updatableModelHero.UpdateLevel(_currentSelectedStatId);
            }).AddTo(_subscriptions);
        }

        public void Dispose()
        {
            _subscriptions?.Dispose();
            _subscriptions = null;
        }
    }
}