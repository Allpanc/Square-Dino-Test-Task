using System.Collections.Generic;
using SquareDinoTestTask.Camera;
using SquareDinoTestTask.Npc;
using SquareDinoTestTask.Player;
using SquareDinoTestTask.Shooting;
using SquareDinoTestTask.UI;
using UnityEditor;
using UnityEngine;

namespace SquareDinoTestTask.Game
{
    [CustomEditor(typeof(CoreSceneBindings))]
    public class CoreSceneBindingsEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            CoreSceneBindings coreSceneBindings = (CoreSceneBindings)target;

            if (GUILayout.Button("Auto Assign Scene Objects"))
            {
                AutoAssignSceneObjects(coreSceneBindings);
            }
        }

        private void AutoAssignSceneObjects(CoreSceneBindings coreSceneBindings)
        {
            coreSceneBindings.way = FindObjectOfType<Way.Way>();
            coreSceneBindings.npcSpawnPoints = new List<NpcSpawnPoint>(FindObjectsOfType<NpcSpawnPoint>());
            coreSceneBindings.playerSpawnPoint = FindObjectOfType<PlayerSpawnPoint>();
            coreSceneBindings.cameraFollower = FindObjectOfType<CameraFollower>();
            coreSceneBindings.projectilesParent = FindObjectOfType<ProjectilesParent>();
            coreSceneBindings.uiRoot = FindObjectOfType<UiRoot>();
            
            EditorUtility.SetDirty(coreSceneBindings);
        }
    }

}