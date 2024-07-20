using UnityEngine;

namespace SquareDinoTestTask.Player
{
    [CreateAssetMenu(menuName = "Square Dino Test Task/Player Config", fileName = "Player Config")]
    public class PlayerConfig : ScriptableObject
    {
        public Player playerPrefab;
        public PlayerStats stats;
    }
}