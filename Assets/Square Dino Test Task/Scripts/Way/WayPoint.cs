using System;
using SquareDinoTestTask.Utils;
using UnityEngine;

namespace SquareDinoTestTask.Way
{
    [RequireComponent(typeof(IWayObstacle))]
    internal class WayPoint : MonoBehaviour
    {
        public event Action OnCompleted;

        public Vector3 StopPosition => triggerObserver.transform.position;

        [SerializeField] 
        private TriggerObserver triggerObserver;
        
        private IWayObstacle obstacle;

        private void Start()
        {
            obstacle = GetComponent<IWayObstacle>();
            triggerObserver.TriggerEnter += HandleTriggerEnter;
        }

        private void HandleTriggerEnter(Collider collider)
        {
            triggerObserver.TriggerEnter -= HandleTriggerEnter;

            obstacle.OnCleared += HandleObstacleCleared;
            obstacle.Activate();
        }

        private void HandleObstacleCleared()
        {
            OnCompleted?.Invoke();
        }
    }
}