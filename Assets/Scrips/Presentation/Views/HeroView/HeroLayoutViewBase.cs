using System;
using System.Collections.Generic;
using System.Linq;
using Scrips.Domain.Models.HeroStats;
using Settings;
using UnityEngine;
using UnityEngine.UIElements;

namespace Scrips.Presentation.Views.HeroView
{
    public class HeroLayoutViewBase : LayoutViewBase, IHeroView
    {
        [SerializeField] private UIDocument _uiDocument;
        [SerializeField] private TextLabels _textLabels;
        [SerializeField] private VisualTreeAsset _statLabelPrefab;
        
        private Label _currentHeroLevel;
        private Label[] _statsLabels;
        private ListView _statsLabelsRoot;
        private Button _levelUpButton;
        
        protected override void Awake()
        {
            base.Awake();
            
            _currentHeroLevel = root.Q<Label>("current_hero_level");
            _statsLabelsRoot = root.Q<ListView>("stat_labels_root");
            _levelUpButton = root.Q<Button>("level_up_button");
        }

        public void UpdateHeroStats(IReadOnlyList<ICharacterStatData> currentStats)
        {
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

        public void UpdateHeroLevel(int currentLevel)
        {
            _currentHeroLevel.text = _textLabels.CurrentLevelLabel + currentLevel;
        }

        public void UpdateLevelUpPrice(long nextLevelPrice)
        {
            _levelUpButton.text = _textLabels.LevelUpButtonText + nextLevelPrice.ToString("F0");
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