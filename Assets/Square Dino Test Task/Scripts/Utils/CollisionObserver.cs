using System;
using UnityEngine;

namespace SquareDinoTestTask.Utils
{
    [RequireComponent(typeof(Collider))]
    public class CollisionObserver : MonoBehaviour
    {
        public event Action<Collision> CollisionEnter;
        public event Action<Collision> CollsiionExit;

        private void OnCollisionEnter(Collision collision)
        {
            CollisionEnter?.Invoke(collision);
        }

        private void OnCollisionExit(Collision collision)
        {
            CollsiionExit?.Invoke(collision);
        }
    }
}