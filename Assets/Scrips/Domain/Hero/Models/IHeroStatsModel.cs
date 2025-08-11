using R3;
using Scrips.Domain.HeroStats.Models;

namespace Scrips.Domain.Hero.Models
{
    public interface IHeroStatsModel
    {
        public int CurrentLevel();
        public ReactiveProperty<ICharacterStat[]> CurrentStats { get; }
    }
}
