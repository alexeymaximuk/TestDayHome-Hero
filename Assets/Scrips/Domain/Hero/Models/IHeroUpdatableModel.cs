using Cysharp.Threading.Tasks;

namespace Scrips.Domain.Hero.Models
{
    public interface IHeroUpdatableModel
    {
        public UniTask UpdateLevel();
    }
}