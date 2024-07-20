using System.Collections.Generic;
using SquareDinoTestTask.Camera;
using SquareDinoTestTask.Npc;
using SquareDinoTestTask.Player;
using SquareDinoTestTask.Shooting;
using SquareDinoTestTask.UI;
using UnityEngine;

namespace SquareDinoTestTask.Game
{
    public class CoreSceneBindings : MonoBehaviour
    {
        public Way.Way way;

        public List<NpcSpawnPoint> npcSpawnPoints;

        public PlayerSpawnPoint playerSpawnPoint;

        public CameraFollower cameraFollower;

        public ProjectilesParent projectilesParent;

        public UiRoot uiRoot;
    }
}