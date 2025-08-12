using System.Collections.Generic;
using Scrips.Domain.Models.HeroStats;
using UnityEngine;
using UnityEngine.UIElements;

namespace Scrips.Presentation.Views.HeroStatsView
{
    public interface IHeroStatsView
    {
        public void UpdateHeroStats(IReadOnlyList<ICharacterStatData> currentStats);
        public bool TryToPickElement(Vector2 position, out VisualElement element);
    }
}