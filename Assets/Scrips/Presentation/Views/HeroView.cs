using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Scrips.Domain.HeroStats.Models;
using Settings;
using UnityEngine;
using UnityEngine.UIElements;

namespace Scrips.Presentation.Views
{
    public class HeroView : View, IHeroView
    {
        [SerializeField] private UIDocument _uiDocument;
        [SerializeField] private TextLabels _textLabels;
        [SerializeField] private VisualTreeAsset _statLabelPrefab;
        
        private Label _levelUpPriceValue, _currentHeroLevel, _currentCoins;
        private Label[] _statsLabels;
        private ListView _statsLabelsRoot;
        private Button _levelUpButton;
        
        private void Awake()
        {
            var root = _uiDocument.rootVisualElement;
            _currentCoins = root.Q<Label>("current_coins_amount");
            _currentHeroLevel = root.Q<Label>("current_hero_level");
            
            _statsLabelsRoot = root.Q<ListView>("stat_labels_root");
            
            _levelUpButton = root.Q<Button>("level_up_button");
        }


        public void UpdateHeroStats(int currentLevel, float levelUpCost, IReadOnlyList<ICharacterStatData> currentStats)
        {
            _currentHeroLevel.text = _textLabels.CurrentLevelLabel + currentLevel;
            _levelUpButton.text = _textLabels.LevelUpButtonText + levelUpCost.ToString("F0");

            _statsLabelsRoot.makeItem = () =>
            {
                var newListEntry = _statLabelPrefab.Instantiate();
                var newListEntryLogic = new CharacterStatDataLabel();

                newListEntry.userData = newListEntryLogic;
                newListEntryLogic.SetVisualElement(newListEntry);

                return newListEntry;
            };

            _statsLabelsRoot.bindItem = (item, index) =>
            {
                (item.userData as CharacterStatDataLabel)?.SetCharacterData(currentStats[index]);
            };

            _statsLabelsRoot.fixedItemHeight = 45;
            _statsLabelsRoot.itemsSource = currentStats.ToList();
        }

        public void UpdateCoinsStats(long currentCoins)
        {
            _currentCoins.text = _textLabels.CurrentMoneyText + currentCoins;
        }

        public void AddOnButtonClickedAction(Action action)
        {
            _levelUpButton.clicked += action;
        }

        public void RemoveOnButtonClickedAction(Action action)
        {
            _levelUpButton.clicked -= action;
        }
    }
}