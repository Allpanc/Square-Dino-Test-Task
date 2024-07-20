using SquareDinoTestTask.Npc;
using SquareDinoTestTask.Player;
using SquareDinoTestTask.Shooting;
using SquareDinoTestTask.UI;
using UnityEngine;
using Zenject;

namespace SquareDinoTestTask.Game
{
    public class CoreMonoInstaller : MonoInstaller
    {
        [SerializeField] 
        private Way.Way way;
        
        public override void InstallBindings()
        {
            BindInstance(way);
            BindSingle<PlayerFactory>();
            BindSingle<NpcFactory>();
            BindSingle<ProjectilePool>();
            BindSingle<ProjectileFactory>();
            BindSingle<ProjectileSpawner>();
            BindSingle<MenuFactory>();
        }
        
        private void BindSingle<T>()
        {
            Container.Bind<T>().AsSingle();
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