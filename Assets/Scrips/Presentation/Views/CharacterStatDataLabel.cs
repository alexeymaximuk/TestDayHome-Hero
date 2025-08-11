using Scrips.Domain.HeroStats.Models;
using UnityEngine.UIElements;

namespace Scrips.Presentation.Views
{
    public class CharacterStatDataLabel
    {
        private Label label;
    
        // This function retrieves a reference to the 
        // character name label inside the UI element.
        public void SetVisualElement(VisualElement visualElement)
        {
            label = visualElement.Q<Label>("character_stat_default");
        }
    
        // This function receives the character whose name this list 
        // element is supposed to display. Since the elements list 
        // in a `ListView` are pooled and reused, it's necessary to 
        // have a `Set` function to change which character's data to display.
        public void SetCharacterData(ICharacterStatData characterData)
        {
            var visuals = characterData.GetStatVisuals();
            label.text = visuals.StatName + " : " + characterData.GetCurrentValue().ToString("F0");
            label.style.color = visuals.StatColor;
        }
    }
}