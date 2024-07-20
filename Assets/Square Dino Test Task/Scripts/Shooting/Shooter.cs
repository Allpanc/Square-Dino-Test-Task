using UnityEngine;
using Zenject;

namespace SquareDinoTestTask.Shooting
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] 
        Transform shootOrigin;

        [SerializeField] 
        private LayerMask targetLayers;
        
        private float lastShotTime;
        private bool isReady = true;
        private ShooterConfig shooterConfig;
        private ProjectilePool projectilePool;
        private Camera mainCamera;

        [Inject]
        private void Construct(
            ProjectilePool projectilePool, 
            ShooterConfig shooterConfig)
        {
            this.projectilePool = projectilePool;
            this.shooterConfig = shooterConfig;
            mainCamera = Camera.main;
        }
        
        private void Update()
        {
            if (NotReadyToShoot())
            {
                return;
            }
            
            isReady = true;
        }

        public void Fire(Vector3 shotPosition)
        {
            if (!isReady)
            {
                return;
            }

            Projectile projectile = projectilePool.Get();
            
            if (projectile == null)
            {
                return;
            }

            Vector3 shootingDirection = GetShootDirection(shotPosition);
            ConfigureProjectile(projectile, shootingDirection);

            lastShotTime = Time.time;
            isReady = false;
        }

        private void ConfigureProjectile(Projectile projectile, Vector3 shootingDirection)
        {
            projectile.transform.position = shootOrigin.position;
            
            Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
            
            projectileRigidbody.freezeRotation = false;
            projectile.transform.forward = shootingDirection.normalized;
            projectileRigidbody.freezeRotation = true;

            projectileRigidbody.AddForce(shootingDirection * shooterConfig.shootForce, ForceMode.Impulse);
        }

        private Vector3 GetShootDirection(Vector3 shotPosition)
        {
            Ray ray = mainCamera.ScreenPointToRay(shotPosition);
            
            if (Physics.Raycast(ray, out RaycastHit hit,1000, targetLayers))
            {
                Vector3 targetPoint = hit.point;
                Vector3 direction = (targetPoint - shootOrigin.position).normalized;
                return direction;
            }
            else
            {
                Vector3 direction = (ray.GetPoint(shooterConfig.fallbackRayPointDistance) - shootOrigin.position).normalized;
                return direction;
            }
        }

        private bool NotReadyToShoot()
        {
            return Time.time - lastShotTime <= shooterConfig.timeBetweenShots;
        }
    }
}