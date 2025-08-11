using System;
using MessagePipe;
using Scrips.Domain.Hero.MessagesDTO;
using Scrips.Domain.Hero.Models;
using Scrips.Domain.Wallet.Models;
using VContainer;
using VContainer.Unity;

namespace Scrips.Application.UseCases
{
    public class HeroUpdateUseCase : IStartable, IDisposable
    {
        private readonly IHeroUpdatableModel _updatableModelHero;
        private readonly IWalletModel _walletModel;
        private readonly ISubscriber<LevelUpButtonClickedDTO> _subscriber;
        private IDisposable _subscription;
        
        [Inject]
        public HeroUpdateUseCase(IHeroUpdatableModel updatableModelHero, IWalletModel walletModel, ISubscriber<LevelUpButtonClickedDTO> subscriber)
        {
            _updatableModelHero = updatableModelHero;
            _walletModel = walletModel;
            _subscriber = subscriber;
        }
        
        public void Start()
        {
            _subscription = _subscriber.Subscribe( buttonClickedData =>
            {
                var coinsForNextLevel = _walletModel.CalculateLevelUpPriceForLevel(buttonClickedData.CurrentLevel);
                var wasPurchaseCompleted = _walletModel.TrySpendingAmount(coinsForNextLevel);

                if (wasPurchaseCompleted)
                    _updatableModelHero.UpdateLevel();
            });
        }

        public void Dispose()
        {
            _subscription?.Dispose();
            _subscription = null;
        }
    }
}