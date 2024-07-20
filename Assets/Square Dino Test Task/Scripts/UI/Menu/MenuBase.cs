using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace SquareDinoTestTask.UI
{
    public abstract class MenuBase : MonoBehaviour
    {
        [SerializeField] 
        private CanvasGroup canvasGroup;

        [SerializeField] 
        private float fadeDuration;

        public async UniTask Show()
        {
            await DOTween.Sequence()
                .Append(canvasGroup
                    .DOFade(1, fadeDuration))
                .AppendCallback(() => 
                    SetCanvasGroupInteraction(true))
                .ToUniTask();
        }

        public async UniTask Hide()
        {
            await DOTween.Sequence()
                .AppendCallback(() => SetCanvasGroupInteraction(false))
                .Append(canvasGroup
                    .DOFade(0, fadeDuration))
                .ToUniTask();;
        }

        private void SetCanvasGroupInteraction(bool state)
        {
            canvasGroup.blocksRaycasts = state;
            canvasGroup.interactable = state;
        }
    }
}