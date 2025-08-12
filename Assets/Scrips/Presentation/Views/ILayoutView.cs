using Cysharp.Threading.Tasks;

namespace Scrips.Presentation.Views
{
    public interface ILayoutView
    {
        UniTask HideAsync();
        UniTask ShowAsync();
    }
}