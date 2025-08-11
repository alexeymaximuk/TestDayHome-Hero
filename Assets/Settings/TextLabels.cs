using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(menuName = "Hero/HeroUpdateMenuLocalization")]
    public class TextLabels : ScriptableObject
    {
        [SerializeField] private string _currentLevelLabel = "Current level: ";
        [SerializeField] private string _levelUpButtonText = "Level up!";
        [SerializeField] private string _currentMoneyText = "Current coins amount: ";
        
        public string CurrentLevelLabel => _currentLevelLabel;
        public string LevelUpButtonText => _levelUpButtonText;
        public string CurrentMoneyText => _currentMoneyText;
    }
}