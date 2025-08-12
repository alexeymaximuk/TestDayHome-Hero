using System;
using MessagePipe;
using R3;
using Scrips.Domain.MessagesDTO;
using Scrips.Domain.Models.Hero;
using VContainer;
using VContainer.Unity;

namespace Scrips.Application.UseCases
{
    public class StatSelectUseCase : IInitializable, IDisposable
    {
        [Inject] private readonly IHeroStatsModel _statsHeroModel;
        [Inject] private readonly ISubscriber<OnHeroStatClickedDTO> _statClickedSubscriber;
        [Inject] private readonly IPublisher<OnHeroStatSelectedDTO> _statSelectedPublisher;

        private readonly CompositeDisposable _compositeDisposable = new ();

        public void Initialize()
        {
            _statClickedSubscriber.Subscribe(message =>
            {
                var currentStats = _statsHeroModel.CurrentStats.CurrentValue;
                for (int i = 0; i < currentStats.Count; i++)
                {
                    if (currentStats[i].GetStatId == message.Id)
                    {
                        //todo add visuals for stat selection
                
                        _statSelectedPublisher.Publish(new OnHeroStatSelectedDTO(message.Id));
                        break;
                    }
                }
            }).AddTo(_compositeDisposable);
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }
    }
}