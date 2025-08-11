using Scrips.Domain.HeroStats.Models;

namespace Scrips.Presentation.Views
{
    public interface IHeroView
    {
        public void UpdateHeroStats(int currentLevel, int levelUpCost, ICharacterStat[] currentStats);
        
        public void UpdateCoinsStats(int currentCoins);
    }
}