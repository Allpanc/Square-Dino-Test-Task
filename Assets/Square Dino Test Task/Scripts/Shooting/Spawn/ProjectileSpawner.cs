using Zenject;

namespace SquareDinoTestTask.Shooting
{
    public class ProjectileSpawner
    {
        private readonly ProjectileFactory factory;
        private readonly ProjectileSpawnerConfig projectileSpawnerConfig;

        [Inject]
        public ProjectileSpawner(
            ProjectileFactory factory, 
            ProjectileSpawnerConfig projectileSpawnerConfig)
        {
            this.factory = factory;
            this.projectileSpawnerConfig = projectileSpawnerConfig;
        }

        public void SpawnProjectiles(ProjectilesParent projectilesParent)
        {
            for (int i = 0; i < projectileSpawnerConfig.spawnAmount; i++)
            {
                factory.Create(projectilesParent);
            }
        }
    }
}