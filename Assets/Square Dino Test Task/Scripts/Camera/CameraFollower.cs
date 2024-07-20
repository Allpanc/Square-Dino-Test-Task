using Cinemachine;
using UnityEngine;

namespace SquareDinoTestTask.Camera
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField]
        private CinemachineVirtualCamera virtualCamera;

        public void SetTarget(CameraTarget target)
        {
            virtualCamera.Follow = target.TargetTransform;
            virtualCamera.LookAt = target.TargetTransform;
        }
    }
}