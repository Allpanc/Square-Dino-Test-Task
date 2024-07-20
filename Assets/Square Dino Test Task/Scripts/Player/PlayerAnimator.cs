using UnityEngine;

namespace SquareDinoTestTask.Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        private static readonly int IsRunning = Animator.StringToHash("isRunning");

        [SerializeField] 
        private Animator animator;

        public void PlayIdle()
        {
            animator.SetBool(IsRunning, false);
        }

        public void PlayRun()
        {
            animator.SetBool(IsRunning, true);
        }
    }
}