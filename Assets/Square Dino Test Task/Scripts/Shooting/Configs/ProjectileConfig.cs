using UnityEngine;

namespace SquareDinoTestTask.Shooting
{
    [CreateAssetMenu(menuName = "Square Dino Test Task/Projectile Config", fileName = "Projectile Config")]
    public class ProjectileConfig : ScriptableObject
    {
        public Projectile projectilePrefab;
        public int damage;
        public float lifeTime;
        public float lifeTimeAfterCollision;
    }
}