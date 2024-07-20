using System.Collections.Generic;

namespace SquareDinoTestTask.Pooling
{
    public class ObjectPool<TPoolable> where TPoolable : IPoolable, new()
    {
        private readonly List<TPoolable> poolables = new();
        public int Size => poolables.Count;

        public void Register(TPoolable poolable)
        {
            if (poolables.Contains(poolable))
            {
                return;
            }
            
            poolables.Add(poolable);
            poolable.IsAvailable = true;
            poolable.OnRegistered();
        }

        public void Unregister(TPoolable poolable)
        {
            if (!poolables.Contains(poolable))
            {
                return;
            }
            
            poolable.OnUnregistered();
            poolables.Remove(poolable);
        }

        public TPoolable Get()
        {
            foreach (var poolable in poolables)
            {
                if (!poolable.IsAvailable)
                {
                    continue;
                }
                
                poolable.OnReadyForRelease += HandleReadyForRelease;
                poolable.OnGetFromPool();
                poolable.IsAvailable = false;
                return poolable;
            }
            
            return default;
        }

        private void HandleReadyForRelease(IPoolable poolable)
        {
            poolable.OnReadyForRelease -= HandleReadyForRelease;
            Release((TPoolable)poolable);
        }

        public void Release(TPoolable poolable)
        {
            if (!poolables.Contains(poolable) || poolable.IsAvailable)
            {
                return;
            }
            
            poolable.OnReleasedIntoPool();
            poolable.IsAvailable = true;
        }
    }
}