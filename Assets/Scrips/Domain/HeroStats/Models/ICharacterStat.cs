namespace Scrips.Domain.HeroStats.Models
{
    public interface ICharacterStat
    {
        public int GetCurrentValue();
        public CharacterStatVisualData GetStatVisuals();
        public void LevelUpStat();
    }
}