using UnityEngine;

namespace SquareDinoTestTask.Npc
{
    public class Npc : MonoBehaviour
    {
        [SerializeField] 
        private Collider collider;
        
        public void Activate()
        {
            collider.enabled = true;
        }
    }
}