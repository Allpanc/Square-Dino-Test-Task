using System;
using SquareDinoTestTask.Services.Input;
using UnityEngine;
using Zenject;

namespace SquareDinoTestTask.Player
{
    public class PlayerInputListener : MonoBehaviour
    {
        public event Action<Vector3> OnInputReceived;
        
        private IInputService inputService;

        [Inject]
        public void Construct(IInputService inputService)
        {
            this.inputService = inputService;
        }

        private void OnEnable()
        {
            inputService.OnTapped += HandleTapped;
        }

        private void OnDisable()
        {
            inputService.OnTapped -= HandleTapped;
        }

        private void HandleTapped()
        {
            OnInputReceived?.Invoke(inputService.TapPosition);
        }
    }
}