using Game.Scripts.Gameplay.ViewsLayer;
using Game.Scripts.Infrastructure;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay.PresentersLayer
{
    public class GameManager : IInitializable
    {
        [Inject] private IShipFactory _shipFactory;
        [Inject] private IPlayerPresenter _playerPresenter;
        private Vector3 StartPlayerAngle { get; } = new Vector3(0, 135f, 0);

        public void Initialize()
        {
            Debug.Log("Game started");
            SpawnPlayerShip(Vector3.zero, Quaternion.Euler(StartPlayerAngle));
        }

        private void SpawnPlayerShip(Vector3 position,
            Quaternion rotation)
        {
            var shipView = _shipFactory.Create(position, rotation, _playerPresenter.UnitPresenter);
            _playerPresenter.InitializePlayer(shipView.transform);
        }
    }
}