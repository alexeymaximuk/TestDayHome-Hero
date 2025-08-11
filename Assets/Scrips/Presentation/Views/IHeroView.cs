using System;
using System.Collections.Generic;
using Scrips.Domain.HeroStats.Models;

namespace Scrips.Presentation.Views
{
    public interface IHeroView
    {
        public void UpdateHeroStats(int currentLevel, float levelUpCost, IReadOnlyList<ICharacterStatData> currentStats);
        
        public void UpdateCoinsStats(long currentCoins);
        public void AddOnButtonClickedAction(Action action);
        public void RemoveOnButtonClickedAction(Action action);
    }
}