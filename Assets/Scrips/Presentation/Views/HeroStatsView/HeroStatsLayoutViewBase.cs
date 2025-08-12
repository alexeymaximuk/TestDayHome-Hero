using System;
using System.Collections.Generic;
using System.Linq;
using Scrips.Domain.Models.HeroStats;
using UnityEngine;
using UnityEngine.UIElements;

namespace Scrips.Presentation.Views.HeroStatsView
{
    public class HeroStatsLayoutViewBase : LayoutViewBase, IHeroStatsView
    {
        [SerializeField] private UIDocument _uiDocument;
        [SerializeField] private VisualTreeAsset _statLabelPrefab;
        
        private ListView _statsLabelsRoot;
        
        protected override void Awake()
        {
            base.Awake();
            
            _statsLabelsRoot = root.Q<ListView>("stat_labels_root");
        }
        
        public bool TryToPickElement(Vector2 worldPosition, out VisualElement visualElement)
        {
            var positionInvertedY = new Vector2(worldPosition.x, Screen.height - worldPosition.y);
            var panel = _uiDocument.rootVisualElement.panel;
            var panelMousePosition = RuntimePanelUtils.ScreenToPanel(panel, positionInvertedY);
            visualElement = panel.Pick(panelMousePosition)?.Q<Label>();
            
            return visualElement != null;
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
    }
}