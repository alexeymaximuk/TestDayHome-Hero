using Cysharp.Threading.Tasks;

namespace Scrips.Application.UseCases
{
    public interface IHeroUseCase
    {
        public UniTask InvokeUseCase();
    }
}