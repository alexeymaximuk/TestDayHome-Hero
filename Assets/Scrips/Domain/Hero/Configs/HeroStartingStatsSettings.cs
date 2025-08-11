using JetBrains.Annotations;
using Scrips.Domain.HeroStats.Models;
using UnityEngine;

namespace Scrips.Domain.Hero.HeroSettings
{
    [CreateAssetMenu(menuName = "Hero/StartingStats")]
    public class HeroStartingStatsSettings : ScriptableObject
    {
        [SerializeReference, NotNull] private ICharacterStat[] _characterStats = {};
        
        public ICharacterStat[] CharacterStats => _characterStats;
    }
}