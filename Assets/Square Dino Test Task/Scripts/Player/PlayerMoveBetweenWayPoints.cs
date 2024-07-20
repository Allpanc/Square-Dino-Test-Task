using System;
using UnityEngine;
using UnityEngine.AI;

namespace SquareDinoTestTask.Player
{
    public class PlayerMoveBetweenWayPoints : MonoBehaviour
    {
        public event Action OnMovementStarted;
        public event Action OnMovementEnded;
        
        [SerializeField] 
        private NavMeshAgent agent;
        
        private Way.Way way;

        private bool isMoving;

        private void Update()
        {
            if (!isMoving)
            {
                return;
            }

            if (!HasReachedDestination())
            {
                return;
            }
            
            OnMovementEnded?.Invoke();
        }

        public void SetSpeed(float speed)
        {
            agent.speed = speed;
        }
        
        public void SetWay(Way.Way way)
        {
            this.way = way;
            this.way.OnWayPointCompleted += HandleWayPointCompleted;
        }

        public void MoveToTargetWayPoint()
        {
            agent.SetDestination(way.TargetWayPointPosition);
            isMoving = true;
            OnMovementStarted?.Invoke();
        }

        private void HandleWayPointCompleted()
        {
            MoveToTargetWayPoint();
        }
        
        private bool HasReachedDestination()
        {
            if (agent.pathPending)
            {
                return false;
            }

            if (!(agent.remainingDistance <= agent.stoppingDistance))
            {
                return false;
            }

            return !agent.hasPath || agent.velocity.sqrMagnitude == 0f;
        }
    }
}