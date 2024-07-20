using DG.Tweening;
using SquareDinoTestTask.Health;
using UnityEngine;
using UnityEngine.UI;

namespace SquareDinoTestTask.UI
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] 
        private Slider slider;

        [SerializeField] 
        private CanvasGroup canvasGroup;

        [SerializeField] 
        private float sliderSpeed;

        [SerializeField] 
        private float fadeDuration;
        
        private Sequence sequence;
        private IHealth health;
        private bool isVisible;

        public void Construct(IHealth health)
        {
            this.health = health;
            this.health.OnHealthChanged += HandleHealthChanged;
        }

        private void HandleHealthChanged()
        {
            SetHealthPercent(health.HealthPercent);
        }

        private void SetHealthPercent(float healthPercent)
        {
            sequence.Kill();
            sequence = DOTween.Sequence();
            
            TryShowSlider();
            ChangeSliderValue(healthPercent);
            TryHideSlider(healthPercent);
        }

        private void TryShowSlider()
        {
            if (isVisible)
            {
                return;
            }
            
            isVisible = true;

            sequence
                .Append(canvasGroup
                    .DOFade(1, fadeDuration));
        }

        private void ChangeSliderValue(float healthPercent)
        {
            sequence.Append(slider
                .DOValue(healthPercent, sliderSpeed)
                .SetSpeedBased());
        }

        private void TryHideSlider(float healthPercent)
        {
            if (healthPercent > 0)
            {
                return;
            }

            sequence
                .Append(canvasGroup
                    .DOFade(0, fadeDuration));
        }
    }
}