using JetBrains.Annotations;
using Scrips.Domain.HeroStats.Models;
using UnityEngine;

namespace Scrips.Domain.Hero.Configs
{
    [CreateAssetMenu(menuName = "Hero/StartingStats")]
    public class HeroStartingStatsSettings : ScriptableObject
    {
        [SerializeField] private CharacterBaseStatSettings[] _characterStatSettings = {};
        
        public CharacterBaseStatSettings[] CharacterStatSettings => _characterStatSettings;
    }
}