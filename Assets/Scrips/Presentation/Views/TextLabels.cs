using UnityEngine;

namespace Scrips.Presentation.Views
{
    [CreateAssetMenu(menuName = "Hero/HeroUpdateMenuLocalization")]
    public class TextLabels : ScriptableObject
    {
        [SerializeField] private string _currentLevelLabel = "Current level: ";
        [SerializeField] private string _levelUpButtonText = "Level up!";
        [SerializeField] private string _currentMoneyText = "Current coins amount: ";
        [SerializeField] private string _levelUpPrice = "Current level: ";
        
        public string CurrentLevelLabel => _currentLevelLabel;
        public string LevelUpButtonText => _levelUpButtonText;
        public string CurrentMoneyText => _currentMoneyText;
        public string LevelUpPrice => _levelUpPrice;
    }
}