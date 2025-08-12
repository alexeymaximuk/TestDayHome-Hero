using System;
using Scrips.Infrastructure.Configs;

namespace Scrips.Domain.Models.HeroStats
{
    [Serializable]
    public sealed class CharacterBaseStat : ICharacterStatData
    {
        private readonly CharacterBaseStatSettings _settings;
        private readonly StatLevelUpSettings _levelUpSettings;
        public float GetCurrentValue() => _currentStatValue;
        public CharacterStatVisualData GetStatVisuals() => new (_settings.Name, _settings.Color);
        public string GetStatId { get; }

        private float _currentStatValue;

        public CharacterBaseStat(CharacterBaseStatSettings settings)
        {
            _settings = settings;
            GetStatId = settings.StatId;
            _levelUpSettings = _settings.LevelUpSettings;
            _currentStatValue = _settings.StartingValue;
        }

        public void LevelUpStat()
        {
            _currentStatValue *= _levelUpSettings.StatIncreasePerLevelModifier;
        }
    }
}