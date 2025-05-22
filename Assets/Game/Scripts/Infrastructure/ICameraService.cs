using UnityEngine;

namespace Game.Scripts.Infrastructure
{
    public interface ICameraService
    {
        void SetupCamera(Transform cameraTarget);
    }
}