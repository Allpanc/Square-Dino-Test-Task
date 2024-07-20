using SquareDinoTestTask.Shooting;
using UnityEngine;

namespace SquareDinoTestTask.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] 
        private PlayerInputListener inputListener;

        [SerializeField] 
        private PlayerAnimator animator;

        [SerializeField] 
        private PlayerMoveBetweenWayPoints playerMove;

        [SerializeField] 
        private Shooter shooter;
        
        private void OnEnable()
        {
            inputListener.OnInputReceived += HandleInputReceived;
            playerMove.OnMovementStarted += HandleMovementStarted;
            playerMove.OnMovementEnded += HandleMovementEnded;
            
            animator.PlayIdle();
        }

        private void OnDisable()
        {
            inputListener.OnInputReceived -= HandleInputReceived;
            playerMove.OnMovementStarted -= HandleMovementStarted;
            playerMove.OnMovementEnded -= HandleMovementEnded;
        }

        private void HandleInputReceived(Vector3 inputPosition)
        {
            shooter.Fire(inputPosition);
        }

        private void HandleMovementStarted()
        {
            animator.PlayRun();
        }

        private void HandleMovementEnded()
        {
            animator.PlayIdle();
        }
    }
}