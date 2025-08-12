using System;
using UnityEngine;

namespace Scrips.Infrastructure.Configs
{
    [Serializable]
    public class CharacterBaseStatSettings
    {
        [SerializeField] private int _startingValue;
        [SerializeField] private string _name;
        [SerializeField] private Color _color;
        [SerializeField] private StatLevelUpSettings _levelUpSettings;
        [SerializeField] private string _statId;

        public int StartingValue => _startingValue;
        public string Name => _name;
        public string StatId => _statId;
        public Color Color => _color;
        public StatLevelUpSettings LevelUpSettings => _levelUpSettings;
    }
}