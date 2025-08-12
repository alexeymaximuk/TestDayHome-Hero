using UnityEngine;

namespace Scrips.Infrastructure.Configs
{
    [CreateAssetMenu(menuName = "Hero/StartingStats")]
    public class HeroStartingStatsSettings : ScriptableObject
    {
        [SerializeField] private CharacterBaseStatSettings[] _characterStatSettings = {};
        
        public CharacterBaseStatSettings[] CharacterStatSettings => _characterStatSettings;
    }
}