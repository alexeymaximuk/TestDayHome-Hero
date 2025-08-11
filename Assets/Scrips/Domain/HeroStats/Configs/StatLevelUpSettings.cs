using UnityEngine;

namespace Scrips.Domain.HeroStats.HeroStatSettings
{
    [CreateAssetMenu(menuName = "HeroStats/StatLevelUpSpeed")]
    public class StatLevelUpSettings : ScriptableObject
    {
        [SerializeField] private float _statIncreasePerLevelModifier = 1.2f;

        public float StatIncreasePerLevelModifier => _statIncreasePerLevelModifier;
    }
}