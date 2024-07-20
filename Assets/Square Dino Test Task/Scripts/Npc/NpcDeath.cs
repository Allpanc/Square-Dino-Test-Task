using SquareDinoTestTask.Health;
using UnityEngine;

namespace SquareDinoTestTask.Npc
{
    public class NpcDeath : MonoBehaviour
    {
        [SerializeField] 
        private NpcRagdoll npcRagdoll;

        [SerializeField] 
        private Animator animator;

        private IHealth health;
        
        public void SetHealth(IHealth health)
        {
            this.health = health;
            this.health.OnHealthChanged += HandleHealthChanged;
        }

        private void HandleHealthChanged()
        {
            if (health.HealthPercent > 0)
            {
                return;
            }
            
            health.OnHealthChanged += HandleHealthChanged;
            animator.enabled = false;
            npcRagdoll.EnableRagdoll();
        }
    }
}