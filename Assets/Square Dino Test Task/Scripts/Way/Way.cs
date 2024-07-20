using System;
using System.Collections.Generic;
using UnityEngine;

namespace SquareDinoTestTask.Way
{
    public class Way : MonoBehaviour
    {
        public Vector3 TargetWayPointPosition => wayPoints[targetWayPointIndex].StopPosition;

        public event Action OnWayPointCompleted;
        public event Action OnCompleted;

        [SerializeField] 
        private List<WayPoint> wayPoints;

        private int targetWayPointIndex;

        private void Start()
        {
            SubscribeToWayPoints();
        }

        private void SubscribeToWayPoints()
        {
            foreach (var wayPoint in wayPoints)
            {
                wayPoint.OnCompleted += HandleWayPointCompleted;
            }
        }

        private void UnsubscribeFromWayPoints()
        {
            foreach (var wayPoint in wayPoints)
            {
                wayPoint.OnCompleted -= HandleWayPointCompleted;
            }
        }

        private void HandleWayPointCompleted()
        {
            targetWayPointIndex = Mathf.Min(targetWayPointIndex + 1, wayPoints.Count);
            
            if (targetWayPointIndex < wayPoints.Count)
            {
                OnWayPointCompleted?.Invoke();
                return;
            }
            
            UnsubscribeFromWayPoints();
            OnCompleted?.Invoke();
        }
    }
}