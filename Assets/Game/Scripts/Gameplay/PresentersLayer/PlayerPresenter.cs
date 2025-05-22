using Game.Scripts.Infrastructure;
using UnityEngine;

namespace Game.Scripts.Gameplay.PresentersLayer
{
    public class PlayerPresenter : IPlayerPresenter, ISailPowerChangeUseCase, IRotationPowerChangeUseCase
    {
        public UnitPresenter UnitPresenter { get; } = new();
        private readonly ICameraService _cameraService;

        public PlayerPresenter(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }

        public void InitializePlayer(Transform transform)
        {
            _cameraService.SetupCamera(transform);
        }
        
        void ISailPowerChangeUseCase.Execute(float power)
        {
            UnitPresenter.SailMode(power);
        }
        
        void IRotationPowerChangeUseCase.Execute(float power)
        {
            UnitPresenter.Rotate(power);
        }
    }

    public interface IRotationPowerChangeUseCase
    {
        void Execute(float power);
    }

    public interface ISailPowerChangeUseCase
    {
        void Execute(float power);
    }

    public interface IPlayerPresenter
    {
        UnitPresenter UnitPresenter { get; }
        void InitializePlayer(Transform transform);
    }
}