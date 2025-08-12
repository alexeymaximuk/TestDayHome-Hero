using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using R3;
using Scrips.Domain.Models.HeroStats;
using Scrips.Infrastructure.Configs;
using UnityEngine;

namespace Scrips.Domain.Models.Hero
{
    public class HeroModel : IHeroStatsModel, IHeroUpdatableModel
    {
        public ReactiveProperty<IReadOnlyList<ICharacterStatData>> CurrentStats { get; }
        private readonly IReadOnlyList<CharacterBaseStat> _characterBaseStats;
        private readonly HeroLevelUpSettings _levelUpSettings;
        
        public ReactiveProperty<int> CurrentLevel { get; }
        public ReactiveProperty<long> NextLevelPrice { get; }
        
        
        public HeroModel(HeroStartingStatsSettings startingStatsSettings, HeroLevelUpSettings levelUpSettings)
        {
            _levelUpSettings = levelUpSettings;
            
            CurrentLevel = new ReactiveProperty<int>(1);
            
            NextLevelPrice = new ReactiveProperty<long>(CalculateLevelUpPriceForLevel(1));

            var statsList = new List<CharacterBaseStat>();
            for (int i = 0; i < startingStatsSettings.CharacterStatSettings.Length; i++)
            {
                var statSettings = startingStatsSettings.CharacterStatSettings[i];
                var newStat = new CharacterBaseStat(statSettings);
                statsList.Add(newStat);
            }

            
            _characterBaseStats = statsList;
            CurrentStats = new ReactiveProperty<IReadOnlyList<ICharacterStatData>>(_characterBaseStats);
            NextLevelPrice = new ReactiveProperty<long>(CalculateLevelUpPriceForLevel(CurrentLevel.CurrentValue));
        }

        public UniTask UpdateLevel()
        {
            CurrentLevel.Value += 1;
            
            for (var i = 0; i < _characterBaseStats.Count; i++)
            {
                _characterBaseStats[i].LevelUpStat();
            }

            CurrentStats.OnNext(_characterBaseStats);
            
            NextLevelPrice.Value = CalculateLevelUpPriceForLevel(CurrentLevel.CurrentValue);
            return UniTask.CompletedTask;
        }
        
        
        public long CalculateLevelUpPriceForLevel(int level)
        {
            var oneLevelUpPrice = (long)(_levelUpSettings.RequiredCoinsForLevelUp *
                                         Mathf.Pow(_levelUpSettings.CoinsIncreasePerLevelMultiplier, level - 1));

            return oneLevelUpPrice;
        }
    }
}