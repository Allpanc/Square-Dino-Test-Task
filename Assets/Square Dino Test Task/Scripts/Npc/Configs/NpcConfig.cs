using UnityEngine;

namespace SquareDinoTestTask.Npc
{
    [CreateAssetMenu(menuName = "Square Dino Test Task/Npc Config", fileName = "Npc Config")]
    public class NpcConfig : ScriptableObject
    {
        public Npc npcPrefab;
        public NpcStats stats;
    }
}