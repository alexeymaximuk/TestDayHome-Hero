using System;
using MessagePipe;
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
        [Inject] private readonly ISubscriber<LevelUpButtonClickedDTO> _subscriber;
        private IDisposable _subscription;
        
        public void Initialize()
        {
            _subscription = _subscriber.Subscribe( buttonClickedData =>
            {
                var coinsForNextLevel = _updatableModelHero.NextLevelPrice.CurrentValue;
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