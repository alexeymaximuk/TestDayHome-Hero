using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Scrips.Presentation
{
    public abstract class View : MonoBehaviour, IView
    {
        public virtual UniTask ShowView()
        {
            gameObject.SetActive(true);
            return UniTask.CompletedTask;
        }

        public UniTask HideView()
        {
            gameObject.SetActive(false);
            return UniTask.CompletedTask;
        }
    }
}