using System;

namespace SquareDinoTestTask.Pooling
{
    public interface IPoolable
    {
        event Action<IPoolable> OnReadyForRelease;
        public bool IsAvailable { get; set; }
        public void OnRegistered();
        public void OnUnregistered();
        public void OnGetFromPool();
        public void OnReleasedIntoPool();
    }
}
