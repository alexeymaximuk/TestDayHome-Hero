namespace Scrips.Domain.Models.HeroStats
{
    public interface ICharacterStatData
    {
        public float GetCurrentValue();
        public CharacterStatVisualData GetStatVisuals();
    }
}