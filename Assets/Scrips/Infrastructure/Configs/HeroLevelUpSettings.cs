using UnityEngine;

namespace Scrips.Infrastructure.Configs
{
    [CreateAssetMenu(menuName = "Hero/LevelUpConfig")]
    public class HeroLevelUpSettings : ScriptableObject
    {
        [SerializeField] private int _requiredCoinsForLevelUp = 100;
        [SerializeField] private float _coinsIncreasePerLevelMultiplier = 2f;
        
        public int RequiredCoinsForLevelUp => _requiredCoinsForLevelUp;
        public float CoinsIncreasePerLevelMultiplier => _coinsIncreasePerLevelMultiplier;
    }
}