using Cysharp.Threading.Tasks;

namespace Scrips.Presentation
{
    public interface IView
    {
        UniTask ShowView();
        UniTask HideView();
    }
}