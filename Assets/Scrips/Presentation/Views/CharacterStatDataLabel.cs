using Scrips.Domain.Models.HeroStats;
using UnityEngine.UIElements;

namespace Scrips.Presentation.Views
{
    public class CharacterStatDataLabel
    {
        private Label _label;
    
        public void SetVisualElement(VisualElement visualElement)
        {
            _label = visualElement.Q<Label>("character_stat_default");
        }
    
        public void SetCharacterData(ICharacterStatData characterData)
        {
            var visuals = characterData.GetStatVisuals();
            _label.name = characterData.GetStatId;
            _label.text = visuals.StatName + " : " + characterData.GetCurrentValue().ToString("F0");
            _label.style.color = visuals.StatColor;
        }
    }
}