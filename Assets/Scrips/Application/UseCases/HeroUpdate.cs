using Cysharp.Threading.Tasks;
using Scrips.Application.UseCases;
using Scrips.Domain.Hero.Models;
using VContainer;

namespace Scrips.Domain.Hero.UseCases
{
    public class HeroUpdateUseCase : IHeroUseCase
    {
        private readonly IHeroUpdatableModel _updatableModelHero;
        
        [Inject]
        public HeroUpdateUseCase(IHeroUpdatableModel updatableModelHero)
        {
            _updatableModelHero = updatableModelHero;
        }
        
        public async UniTask InvokeUseCase()
        {
            await UpdateLevel();
        }
        
        private async UniTask UpdateLevel()
        {  
            await _updatableModelHero.UpdateLevel();
        }
    }
}