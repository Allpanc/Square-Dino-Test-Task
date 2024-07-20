using System;
using UnityEngine;
using UnityEngine.UI;

namespace SquareDinoTestTask.UI
{
    public class StartMenu : MenuBase
    {
        public event Action OnStartButtonClick;
        
        [SerializeField] 
        private Button startGameButton;

        private void OnEnable()
        {
            startGameButton.onClick.AddListener(HandleStartButtonClick);
        }

        private void OnDisable()
        {
            startGameButton.onClick.RemoveListener(HandleStartButtonClick);
        }

        private void HandleStartButtonClick()
        {
            OnStartButtonClick?.Invoke();
        }
    }
}