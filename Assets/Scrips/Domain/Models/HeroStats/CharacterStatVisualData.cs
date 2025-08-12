using UnityEngine;

namespace Scrips.Domain.Models.HeroStats
{
    public struct CharacterStatVisualData
    {
        public CharacterStatVisualData(string statName, Color statColor)
        {
            StatName = statName;
            StatColor = statColor;
        }
        
        public readonly string StatName;
        public readonly Color StatColor;
    }
}