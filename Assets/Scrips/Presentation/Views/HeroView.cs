using JetBrains.Annotations;
using Scrips.Domain.HeroStats.Models;
using UnityEngine;
using UnityEngine.UIElements;

namespace Scrips.Presentation.Views
{
    public class HeroView : View, IHeroView
    {
        [SerializeField, NotNull] private UIDocument _uiDocument;
        [SerializeField, NotNull] private TextLabels _textLabels;
        
        private Label _levelUpPriceValue, _currentHeroLevel, _currentCoins;
        private Label[] _statsLabels;
        private VisualElement _statsLabelsRoot;
        private Button _levelUpButton;
        private void Awake()
        {
            var root = _uiDocument.rootVisualElement;
            _currentCoins = root.Q<Label>("current_coins_amount");
            //_levelUpPriceValue = root.Q<Label>("level_up_price_label");
            _currentHeroLevel = root.Q<Label>("current_hero_level");

            _statsLabelsRoot = root.Q("stat_labels_root");

            _levelUpButton = root.Q<Button>("level_up_button");
        }
        
        
        public void UpdateHeroStats(int currentLevel, int levelUpCost, ICharacterStat[] currentStats)
        {
            _currentHeroLevel.text = _textLabels.CurrentLevelLabel + currentLevel;
            _levelUpPriceValue.text = _textLabels.LevelUpPrice + levelUpCost;
        }

        public void UpdateCoinsStats(int currentCoins)
        {
            _currentCoins.text = _textLabels.CurrentMoneyText + currentCoins;
        }
    }
}