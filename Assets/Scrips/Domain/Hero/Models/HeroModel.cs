using Cysharp.Threading.Tasks;
using R3;
using Scrips.Domain.Hero.HeroSettings;
using Scrips.Domain.HeroStats.Models;
using VContainer;

namespace Scrips.Domain.Hero.Models
{
    public class HeroModel : IHeroStatsModel, IHeroUpdatableModel
    {
        private readonly ReactiveProperty<ICharacterStat[]> _characterStats;

        private int _currentLevel;
        
        int IHeroStatsModel.CurrentLevel() => _currentLevel;
        public ReactiveProperty<ICharacterStat[]> CurrentStats => _characterStats;
        
        public HeroModel(HeroStartingStatsSettings startingStatsSettings)
        {
            _currentLevel = 1;

            _characterStats = new ReactiveProperty<ICharacterStat[]>(startingStatsSettings.CharacterStats);
        }

        public UniTask UpdateLevel()
        {
            _currentLevel++;
            
            var currentValue = _characterStats.Value;
            for (int i = 0; i < currentValue.Length; i++)
            {
                currentValue[i].LevelUpStat();
            }

            _characterStats.Value = currentValue;
            
            return UniTask.CompletedTask;
        }

    }
}