using SquareDinoTestTask.Health;
using SquareDinoTestTask.UI;
using UnityEngine;
using Zenject;

namespace SquareDinoTestTask.Npc
{
    public class NpcFactory
    {
        private readonly DiContainer container;
        private readonly NpcConfig npcConfig;

        [Inject]
        public NpcFactory(DiContainer container, NpcConfig npcConfig)
        {
            this.container = container;
            this.npcConfig = npcConfig;
        }

        public Npc Create(NpcSpawnPoint spawnPoint)
        {
            Transform spawnPointTransform = spawnPoint.transform;
            
            Npc npc = container.InstantiatePrefabForComponent<Npc>(
                npcConfig.npcPrefab, 
                spawnPointTransform.position, 
                Quaternion.identity, 
                spawnPointTransform);

            spawnPoint.NpcLocation.Register(npc);
            
            ConfigureNpc(npc);
            
            return npc;
        }

        private void ConfigureNpc(Npc npc)
        {
            IHealth health = npc
                .GetComponent<IHealth>();

            health
                .SetMaxHealth(npcConfig.stats.health);
            
            npc
                .GetComponentInChildren<HealthView>()
                .Construct(health);

            npc
                .GetComponent<NpcDeath>()
                .SetHealth(health);
        }
    }
}