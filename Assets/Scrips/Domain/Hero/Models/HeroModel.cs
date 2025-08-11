using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using R3;
using Scrips.Domain.Hero.Configs;
using Scrips.Domain.HeroStats.Models;

namespace Scrips.Domain.Hero.Models
{
    public class HeroModel : IHeroStatsModel, IHeroUpdatableModel
    {
        public ReactiveProperty<IReadOnlyList<ICharacterStatData>> CurrentStats { get; }
        private readonly IReadOnlyList<CharacterBaseStat> _characterBaseStats;
        
        private int _currentLevel;
        public int CurrentLevel() => _currentLevel;
        
        
        public HeroModel(HeroStartingStatsSettings startingStatsSettings)
        {
            _currentLevel = 1;

            var statsList = new List<CharacterBaseStat>();
            for (int i = 0; i < startingStatsSettings.CharacterStatSettings.Length; i++)
            {
                var statSettings = startingStatsSettings.CharacterStatSettings[i];
                var newStat = new CharacterBaseStat(statSettings);
                statsList.Add(newStat);
            }
            
            _characterBaseStats = statsList;
            
            CurrentStats = new ReactiveProperty<IReadOnlyList<ICharacterStatData>>(_characterBaseStats);
        }

        public UniTask UpdateLevel()
        {
            _currentLevel++;
            
            for (var i = 0; i < _characterBaseStats.Count; i++)
            {
                _characterBaseStats[i].LevelUpStat();
            }

            CurrentStats.OnNext(_characterBaseStats);
            
            return UniTask.CompletedTask;
        }

    }
}