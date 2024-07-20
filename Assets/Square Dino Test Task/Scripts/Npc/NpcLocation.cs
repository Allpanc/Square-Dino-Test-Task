using System;
using System.Collections.Generic;
using SquareDinoTestTask.Health;
using SquareDinoTestTask.Way;
using UnityEngine;

namespace SquareDinoTestTask.Npc
{
    public class NpcLocation : MonoBehaviour, IWayObstacle
    {
        public event Action OnCleared;
        
        private List<Npc> npcs = new();
        private List<IHealth> npcHealths = new();
        private int npcCount;

        public void Register(Npc npc)
        {
            npcs.Add(npc);
            
            IHealth health = npc.GetComponent<IHealth>();
            npcHealths.Add(health);
        }
        
        public void Activate()
        {
            npcCount = npcs.Count;
            SubsribeToNpcHealths();
            ActivateNpcs();
            CheckCompletion();
        }

        private void SubsribeToNpcHealths()
        {
            foreach (IHealth health in npcHealths)
            {
                health.OnNoHealthLeft += HandleNoHealthLeft;
            }
        }

        private void UnsubsribeFromNpcHealths()
        {
            foreach (IHealth health in npcHealths)
            {
                health.OnNoHealthLeft -= HandleNoHealthLeft;
            }
        }

        private void ActivateNpcs()
        {
            foreach (Npc npc in npcs)
            {
                npc.Activate();
            }
        }

        private void HandleNoHealthLeft()
        {
            npcCount--;

            CheckCompletion();
        }

        private void CheckCompletion()
        {
            if (npcCount > 0)
            {
                return;
            }
            
            UnsubsribeFromNpcHealths();
            OnCleared?.Invoke();
        }
    }
}