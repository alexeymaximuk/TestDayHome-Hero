using System;
using System.Diagnostics.CodeAnalysis;
using Scrips.Domain.HeroStats.HeroStatSettings;
using UnityEngine;

namespace Scrips.Domain.HeroStats.Models
{
    [Serializable]
    public abstract class CharacterBaseStat : ICharacterStat
    {
        [SerializeField] private int _startingValue;
        [SerializeField, NotNull] private string _name;
        [SerializeField] private Color _color;
        [SerializeField] private StatLevelUpSettings _levelUpSettings;

        public int GetCurrentValue() => _currentStatValue;
        public CharacterStatVisualData GetStatVisuals() => new (_name, _color);
        
        private int _currentStatValue;

        protected CharacterBaseStat()
        {
            _currentStatValue = _startingValue;
        }

        public void LevelUpStat()
        {
            _currentStatValue = Mathf.CeilToInt(_currentStatValue * _levelUpSettings.StatIncreasePerLevelModifier);
        }
    }
}