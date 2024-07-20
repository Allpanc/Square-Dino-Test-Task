using SquareDinoTestTask.Npc;
using SquareDinoTestTask.Player;
using SquareDinoTestTask.Shooting;
using SquareDinoTestTask.UI;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace SquareDinoTestTask.Game
{
    [CreateAssetMenu(menuName = "Square Dino Test Task/Core Scriptable Installer", fileName = "Core Scriptable Installer")]
    public class CoreScriptableInstaller : ScriptableObjectInstaller
    {
        [SerializeField] 
        private PlayerConfig playerConfig;
        
        [SerializeField] 
        private NpcConfig npcConfig;

        [SerializeField] 
        private ShooterConfig shooterConfig;

        [SerializeField] private ProjectileConfig projectileConfig;
        
        [SerializeField] 
        private ProjectileSpawnerConfig projectileSpawnerFactoryConfig;

        [SerializeField] 
        private MenuPrefabsCollection menuPrefabsCollection;

        public override void InstallBindings()
        {
            BindInstance(playerConfig);
            BindInstance(npcConfig);
            BindInstance(shooterConfig);
            BindInstance(projectileConfig);
            BindInstance(projectileSpawnerFactoryConfig);
            BindInstance(menuPrefabsCollection);
        }
        
        private void BindInstance<TInstance>(TInstance instance)
        {
            Container
                .Bind<TInstance>()
                .FromInstance(instance)
                .AsSingle();
        }
    }
}