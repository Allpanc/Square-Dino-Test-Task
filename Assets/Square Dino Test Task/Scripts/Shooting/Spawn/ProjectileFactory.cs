using UnityEngine;
using Zenject;

namespace SquareDinoTestTask.Shooting
{
    public class ProjectileFactory
    {
        private readonly DiContainer container;
        private readonly ProjectilePool pool;
        private readonly ProjectileConfig projectileConfig;
        private readonly Projectile projectilePrefab;

        [Inject]
        public ProjectileFactory(
            DiContainer container, 
            ProjectilePool pool, 
            ProjectileConfig projectileConfig)
        {
            this.container = container;
            this.pool = pool;
            this.projectileConfig = projectileConfig;
        }

        public Projectile Create(ProjectilesParent parent)
        {
            Projectile projectile = container.InstantiatePrefabForComponent<Projectile>(
                projectileConfig.projectilePrefab, 
                parent.transform.position, 
                Quaternion.identity, 
                parent.transform);

            var context = new Projectile.Context
            {
                damage = projectileConfig.damage,
                lifetime = projectileConfig.lifeTime,
                lifetimeAfterCollision = projectileConfig.lifeTimeAfterCollision
            };
            
            projectile.Prepare(context);

           pool.Register(projectile);

           return projectile;
        }
    }
}