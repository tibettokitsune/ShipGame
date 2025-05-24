using Game.Scripts.Infrastructure;
using Game.Scripts.Infrastructure.TimerService;
using UniRx;
using UnityEngine;

namespace Game.Scripts.Gameplay.PresentersLayer
{
    public class PlayerPresenter : IPlayerPresenter, 
        ISailPowerChangeUseCase, 
        IRotationPowerChangeUseCase,
        IGiveMoneyUseCase
    {
        public ReactiveProperty<int> Coins { get; } = new();
        public ShipPresenter ShipMovementPresenter { get; }
        private readonly ICameraService _cameraService;

        public PlayerPresenter(ICameraService cameraService, ITimerService timerService)
        {
            _cameraService = cameraService;

            ShipMovementPresenter = new ShipPresenter("Player", 
                100f, 
                1f, 
                10f, 
                timerService);
        }

        public void InitializePlayer(Transform transform)
        {
            _cameraService.SetupCamera(transform);
        }

        void ISailPowerChangeUseCase.Execute(float power)
        {
            ShipMovementPresenter.SailMode(power);
        }

        void IRotationPowerChangeUseCase.Execute(float power)
        {
            ShipMovementPresenter.Rotate(power);
        }
        
        void IGiveMoneyUseCase.Execute(int inc)
        {
            Coins.Value += inc;
        }
    }

    public interface IGiveMoneyUseCase
    {
        void Execute(int increment);
    }

    public interface IRotationPowerChangeUseCase
    {
        void Execute(float power);
    }

    public interface ISailPowerChangeUseCase
    {
        void Execute(float power);
    }
}