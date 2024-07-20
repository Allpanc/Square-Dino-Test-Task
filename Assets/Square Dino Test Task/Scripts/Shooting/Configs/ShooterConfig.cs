using UnityEngine;

namespace SquareDinoTestTask.Shooting
{
    [CreateAssetMenu(menuName = "Square Dino Test Task/Shooter Config", fileName = "Shooter Config")]
    public class ShooterConfig : ScriptableObject
    {
        public float shootForce;
        public float timeBetweenShots;
        public float fallbackRayPointDistance;
    }
}