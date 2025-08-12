using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Scrips.Presentation.Views
{
    [RequireComponent(typeof(UIDocument))]
    public abstract class LayoutViewBase : MonoBehaviour, ILayoutView
    {
        protected VisualElement root;
        protected UIDocument uiDocument;
        
        protected virtual void Awake()
        {
            uiDocument = GetComponent<UIDocument>();
            root = uiDocument.rootVisualElement;
        }

        public virtual async UniTask ShowAsync()
        {
            gameObject.SetActive(true);
            await UniTask.Yield();
        }
        
        public virtual async UniTask HideAsync()
        {
            gameObject.SetActive(false);
            await UniTask.Yield();
        }
    }
}