using System;
using System.Collections.Generic;
using Scrips.Domain.Models.HeroStats;

namespace Scrips.Presentation.Views.HeroView
{
    public interface IHeroView
    {
        public void UpdateHeroLevel(int currentLevel);
        public void UpdateLevelUpPrice(long levelUpPrice);
        public void UpdateHeroStats(IReadOnlyList<ICharacterStatData> currentStats);
        public void AddOnButtonClickedAction(Action action);
        public void RemoveOnButtonClickedAction(Action action);
    }
}