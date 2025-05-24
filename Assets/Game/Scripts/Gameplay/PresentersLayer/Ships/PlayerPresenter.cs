using Game.Scripts.Gameplay.DataLayer;
using Game.Scripts.Infrastructure;
using Game.Scripts.Infrastructure.TimerService;
using UniRx;
using UnityEngine;

namespace Game.Scripts.Gameplay.PresentersLayer.Ships
{
    public class PlayerPresenter : IPlayerPresenter,
        ISailPowerChangeUseCase,
        IRotationPowerChangeUseCase,
        IGiveMoneyUseCase
    {
        public IReactiveProperty<int> Coins => _playerDataProvider.Coins;
        public ShipPresenter ShipMovementPresenter { get; }
        private readonly IPlayerDataProvider _playerDataProvider;
        private readonly ICameraService _cameraService;

        public PlayerPresenter(
            IPlayerDataProvider playerDataProvider,
            ICameraService cameraService,
            ITimerService timerService)
        {
            _playerDataProvider = playerDataProvider;
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