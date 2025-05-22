using Unity.Cinemachine;
using UnityEngine;

namespace Game.Scripts.Infrastructure
{
    public class CameraService : ICameraService
    {
        private CinemachineCamera Camera
        {
            get
            {
                if (!_camera)
                {
                    _camera = Object.FindObjectOfType<CinemachineCamera>();
                }
                return _camera;
            }
        }
        private CinemachineCamera _camera;
        public void SetupCamera(Transform cameraTarget) => Camera.Follow = cameraTarget;
    }
}