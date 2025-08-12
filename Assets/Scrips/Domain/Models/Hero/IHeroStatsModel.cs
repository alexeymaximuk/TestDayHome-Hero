using System.Collections.Generic;
using R3;
using Scrips.Domain.Models.HeroStats;

namespace Scrips.Domain.Models.Hero
{
    public interface IHeroStatsModel
    {
        public ReactiveProperty<int> CurrentLevel { get; }
        public ReactiveProperty<IReadOnlyList<ICharacterStatData>> CurrentStats { get; }
        
    }
}
