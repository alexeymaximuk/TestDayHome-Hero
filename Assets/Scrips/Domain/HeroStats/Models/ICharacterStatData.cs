namespace Scrips.Domain.HeroStats.Models
{
    public interface ICharacterStatData
    {
        public float GetCurrentValue();
        public CharacterStatVisualData GetStatVisuals();
    }
}