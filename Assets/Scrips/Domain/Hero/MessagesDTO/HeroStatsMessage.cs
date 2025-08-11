using Scrips.Domain.HeroStats.Models;

namespace Scrips.Domain.Hero.MessagesDTO
{
    public struct HeroStatsMessage
    {
        public int CurrentLevel;
        public CharacterStatVisualData[] CurrentStats;
    }
}