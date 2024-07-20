using SquareDinoTestTask.Health;
using SquareDinoTestTask.Services;
using SquareDinoTestTask.Services.Input;
using UnityEngine;
using Zenject;

namespace SquareDinoTestTask.Player
{
    public class PlayerFactory
    {
        private readonly DiContainer container;
        private readonly PlayerConfig playerConfig;
        private readonly Way.Way way;

        [Inject]
        public PlayerFactory(
            DiContainer container, 
            PlayerConfig playerConfig, 
            Way.Way way)
        {
            this.container = container;
            this.playerConfig = playerConfig;
            this.way = way;
        }
        
        public Player Create(Transform parent)
        {
            Player player = container.InstantiatePrefabForComponent<Player>(
                playerConfig.playerPrefab, 
                parent.position, 
                parent.rotation, 
                parent);

            ConfigurePlayer(player);

            return player;
        }

        private void ConfigurePlayer(Player player)
        {
            IHealth health = player
                .GetComponent<IHealth>();

            health
                .SetMaxHealth(playerConfig.stats.health);

            PlayerMoveBetweenWayPoints playerMove = player
                .GetComponent<PlayerMoveBetweenWayPoints>();
            
            playerMove
                .SetSpeed(playerConfig.stats.speed);
            
            playerMove
                .SetWay(way);
        }
    }
}