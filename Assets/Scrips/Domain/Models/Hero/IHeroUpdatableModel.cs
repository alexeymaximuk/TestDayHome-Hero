using Cysharp.Threading.Tasks;
using R3;

namespace Scrips.Domain.Models.Hero
{
    public interface IHeroUpdatableModel
    {
        public ReactiveProperty<long> NextLevelPrice { get; }
        public UniTask UpdateLevel(string statId);
    }
}