using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Infrastructure.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class UIScreen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private float fadeDuration = 0.3f;

        protected virtual void Awake()
        {
            if (canvasGroup == null)
                canvasGroup = GetComponent<CanvasGroup>();
        }

        public virtual async Task ShowAsync()
        {
            gameObject.SetActive(true);
            
            if (canvasGroup != null)
            {
                canvasGroup.alpha = 0;
                await LerpAlpha(0, 1, fadeDuration);
            }
        }

        public virtual async Task HideAsync()
        {
            if (canvasGroup != null)
            {
                await LerpAlpha(1, 0, fadeDuration);
            }
            
            gameObject.SetActive(false);
        }

        private async Task LerpAlpha(float from, float to, float duration)
        {
            float elapsed = 0;
            while (elapsed < duration)
            {
                canvasGroup.alpha = Mathf.Lerp(from, to, elapsed / duration);
                elapsed += Time.deltaTime;
                await Task.Yield();
            }
            canvasGroup.alpha = to;
        }
    }
}