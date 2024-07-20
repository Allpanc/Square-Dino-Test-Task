using System;

namespace SquareDinoTestTask.Way
{
    public interface IWayObstacle
    {
        event Action OnCleared;
        void Activate();
    }
}