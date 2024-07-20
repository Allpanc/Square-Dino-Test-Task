using UnityEngine;

namespace SquareDinoTestTask.Npc
{
    public class NpcSpawnPoint : MonoBehaviour
    {
        public NpcLocation NpcLocation => npcLocation;
        
        [SerializeField] 
        private NpcLocation npcLocation;
    }
}