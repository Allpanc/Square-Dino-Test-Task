using System;
using UnityEngine;
using Zenject;

namespace SquareDinoTestTask.Services.Input
{
    public interface IInputService : ITickable
    {
        event Action OnTapped;
        Vector3 TapPosition { get; }
        bool IsListening { get; set; }
    }
}