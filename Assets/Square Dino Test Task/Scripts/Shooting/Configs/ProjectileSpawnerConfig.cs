using UnityEngine;

namespace SquareDinoTestTask.Shooting
{
    [CreateAssetMenu(menuName = "Square Dino Test Task/Projectile Spawner Config", fileName = "Projectile Spawner Config")]
    public class ProjectileSpawnerConfig : ScriptableObject
    {
        public int spawnAmount;
    }
}