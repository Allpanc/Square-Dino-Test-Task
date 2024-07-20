using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using SquareDinoTestTask.Health;
using SquareDinoTestTask.Pooling;
using SquareDinoTestTask.Utils;
using UnityEngine;

namespace SquareDinoTestTask.Shooting
{
    public class Projectile : MonoBehaviour, IPoolable
    {
        public class Context
        {
            public int damage;
            public float lifetime;
            public float lifetimeAfterCollision;
        }
        
        public event Action<IPoolable> OnReadyForRelease;
        public bool IsAvailable { get; set; }

        [SerializeField]
        private Rigidbody rigidbody;

        [SerializeField] 
        private CollisionObserver collisionObserver;

        private int damage;
        private float lifetime;
        private float lifetimeAfterCollision;
        private bool isUsed;
        private CancellationTokenSource cancellationTokenSource;

        public void Prepare(Context context)
        {
            damage = context.damage;
            lifetime = context.lifetime;
            lifetimeAfterCollision = context.lifetimeAfterCollision;
        }

        public void OnRegistered()
        {
            collisionObserver.CollisionEnter += HandleCollisionEnter;
            gameObject.SetActive(false);
        }

        public void OnUnregistered()
        {
            collisionObserver.CollisionEnter -= HandleCollisionEnter;
        }

        public void OnGetFromPool()
        {
            isUsed = false;
            cancellationTokenSource = new CancellationTokenSource();
            gameObject.SetActive(true);
            rigidbody.velocity = Vector3.zero;
            rigidbody.useGravity = false;
            ReturnToPoolAfterTimeout(cancellationTokenSource.Token);
        }

        public void OnReleasedIntoPool()
        {
            cancellationTokenSource?.Cancel();
            gameObject.SetActive(false);
        }
        
        private void HandleCollisionEnter(Collision collision)
        {
            if (isUsed)
            {
                return;
            }
            
            isUsed = true;
            TryDealDamage(collision);

            rigidbody.useGravity = true;
            ReturnToPoolAfterCollision(cancellationTokenSource.Token);
        }

        private void TryDealDamage(Collision collision)
        {
            IHealth health = collision.gameObject.GetComponent<IHealth>();
            health?.TakeDamage(damage);
        }

        private async void ReturnToPoolAfterCollision(CancellationToken cancellationToken)
        {
            try
            {
                await UniTask.Delay(TimeSpan.FromSeconds(lifetimeAfterCollision), cancellationToken: cancellationToken);
                OnReadyForRelease?.Invoke(this);
            }
            catch (OperationCanceledException)
            {

            }
        }
        
        private async UniTaskVoid ReturnToPoolAfterTimeout(CancellationToken cancellationToken)
        {
            try
            {
                await UniTask.Delay(TimeSpan.FromSeconds(lifetime), cancellationToken: cancellationToken);
                OnReadyForRelease?.Invoke(this);
            }
            catch (OperationCanceledException)
            {

            }
        }
    }
}