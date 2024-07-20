using UnityEditor;
using UnityEngine;

namespace SquareDinoTestTask.Npc.Editor
{
    [CustomEditor(typeof(NpcRagdoll))]
    public class NpcRagdollEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            NpcRagdoll coreSceneBindings = (NpcRagdoll)target;

            if (GUILayout.Button("Auto Assign Ragdoll Parts"))
            {
                AutoAssignSceneObjects(coreSceneBindings);
            }
        }

        private void AutoAssignSceneObjects(NpcRagdoll npcRagdoll)
        {
            Collider[] colliders = npcRagdoll.GetComponentsInChildren<Collider>();
            Rigidbody[] rigidbodies = npcRagdoll.GetComponentsInChildren<Rigidbody>();
            Collider mainCollider = npcRagdoll.GetComponent<Collider>();
            
            foreach (Collider collider in colliders)
            {
                collider.enabled = false;
            }
            
            foreach (Rigidbody rigidbody in rigidbodies)
            {
                rigidbody.isKinematic = true;
            }
            
            var context = new NpcRagdoll.Context
            {
                ragdollBodies = rigidbodies,
                ragdollColliders = colliders,
                mainCollider = mainCollider
            };

            npcRagdoll.Prepare(context);

            EditorUtility.SetDirty(npcRagdoll);
        }
    }
}