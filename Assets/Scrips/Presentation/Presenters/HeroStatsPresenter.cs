using System;
using System.Collections.Generic;
using MessagePipe;
using R3;
using Scrips.Domain.MessagesDTO;
using Scrips.Domain.Models.Hero;
using Scrips.Domain.Models.HeroStats;
using Scrips.Presentation.Views.HeroStatsView;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using CompositeDisposable = R3.CompositeDisposable;

namespace Scrips.Presentation.Presenters
{
    public class HeroStatsPresenter : IInitializable, IStartable, IDisposable
    {
        [Inject] private readonly IHeroStatsModel _heroStatsModel;
        [Inject] private readonly IHeroStatsView _statsView;
        [Inject] private readonly ISubscriber<OnUserTapDTO> _onUserTapSubscriber;
        [Inject] private readonly IPublisher<OnHeroStatClickedDTO> _onStatClickPublisher;
        
        private readonly CompositeDisposable _compositeDisposable = new ();

        public void Initialize()
        {
        }

        public void Start()
        {
            _onUserTapSubscriber.Subscribe(message => OnUserClick(message.Position)).AddTo(_compositeDisposable);
            _heroStatsModel.CurrentStats.Subscribe(UpdateHeroStats).AddTo(_compositeDisposable);
        }
        
        public void Dispose()
        {   
            _compositeDisposable.Dispose();
        }

        private void OnUserClick(Vector2 position)
        {
            if (_statsView.TryToPickElement(position, out var element))
            {
                _onStatClickPublisher.Publish(new OnHeroStatClickedDTO(element.name));
            }
        }
        
        private void UpdateHeroStats(IReadOnlyList<ICharacterStatData> characterStats)
        {
            _statsView.UpdateHeroStats(characterStats);
        }
    }
}