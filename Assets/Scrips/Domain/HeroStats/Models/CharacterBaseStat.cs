using System;
using Scrips.Domain.HeroStats.Configs;
using UnityEngine;

namespace Scrips.Domain.HeroStats.Models
{
    [Serializable]
    public sealed class CharacterBaseStat : ICharacterStatData
    {
        private readonly CharacterBaseStatSettings _settings;
        private readonly StatLevelUpSettings _levelUpSettings;
        public float GetCurrentValue() => _currentStatValue;
        public CharacterStatVisualData GetStatVisuals() => new (_settings.Name, _settings.Color);
        
        private float _currentStatValue;

        public CharacterBaseStat(CharacterBaseStatSettings settings)
        {
            _settings = settings;
            _levelUpSettings = _settings.LevelUpSettings;
            _currentStatValue = _settings.StartingValue;
        }

        public void LevelUpStat()
        {
            _currentStatValue *= _levelUpSettings.StatIncreasePerLevelModifier;
        }
    }
}