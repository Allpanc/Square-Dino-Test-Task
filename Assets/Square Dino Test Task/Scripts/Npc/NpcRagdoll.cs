using UnityEngine;

namespace SquareDinoTestTask.Npc
{
    public class NpcRagdoll : MonoBehaviour
    {
        public class Context
        {
            public Rigidbody[] ragdollBodies;
            public Collider[] ragdollColliders;
            public Collider mainCollider;
        }
        
        [SerializeField]
        private Rigidbody[] ragdollBodies;

        [SerializeField] 
        private Collider[] ragdollColliders;
        
        [SerializeField] 
        private Collider mainCollider;

        public void Prepare(Context context)
        {
            ragdollBodies = context.ragdollBodies;
            ragdollColliders = context.ragdollColliders;
            mainCollider = context.mainCollider;
        }
        
        public void EnableRagdoll()
        {
            mainCollider.enabled = false;
            SetRagdollState(true);
        }

        private void SetRagdollState(bool state)
        {
            foreach (var body in ragdollBodies)
            {
                body.isKinematic = !state;
            }

            foreach (var collider in ragdollColliders)
            {
                collider.enabled = state;
            }
        }

        public void FixRagdollPhysics()
        {
            foreach (Rigidbody rb in ragdollBodies)
                rb.velocity /= 10;
        }
    }
}