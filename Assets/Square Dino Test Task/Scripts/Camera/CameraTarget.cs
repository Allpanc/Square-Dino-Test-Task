using UnityEngine;

namespace SquareDinoTestTask.Camera
{
    public class CameraTarget : MonoBehaviour
    {
        public Transform TargetTransform => targetTransform;
        
        [SerializeField] 
        private Transform targetTransform;
    }
}