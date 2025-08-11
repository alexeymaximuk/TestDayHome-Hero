using System;
using Scrips.Domain.HeroStats.Configs;
using UnityEngine;

namespace Scrips.Domain.HeroStats.Models
{
    [Serializable]
    public class CharacterBaseStatSettings
    {
        [SerializeField] private int _startingValue;
        [SerializeField] private string _name;
        [SerializeField] private Color _color;
        [SerializeField] private StatLevelUpSettings _levelUpSettings;

        public int StartingValue => _startingValue;
        public string Name => _name;
        public Color Color => _color;
        public StatLevelUpSettings LevelUpSettings => _levelUpSettings;
    }
}