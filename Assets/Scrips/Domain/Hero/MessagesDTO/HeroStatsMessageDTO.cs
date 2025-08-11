using Scrips.Domain.HeroStats.Models;

namespace Scrips.Domain.Hero.MessagesDTO
{
    public struct HeroStatsMessageDTO
    {
        public int CurrentLevel;
        public CharacterStatVisualData[] CurrentStats;
    }
}