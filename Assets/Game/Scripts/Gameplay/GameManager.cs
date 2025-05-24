using System.Collections.Generic;
using Game.Scripts.Gameplay.PresentersLayer;
using Game.Scripts.Gameplay.PresentersLayer.Ships;
using Game.Scripts.Gameplay.ViewsLayer;
using Game.Scripts.Gameplay.ViewsLayer.Ships;
using Game.Scripts.Infrastructure.TimerService;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay
{
    public class GameManager : IInitializable
    {
        [Inject] private IShipFactory _shipFactory;
        [Inject] private IPlayerPresenter _playerPresenter;
        [Inject] private IGiveMoneyUseCase _giveMoneyUseCase;
        [Inject] private ITimerService _timerService;
        [Inject(Id = "EnemiesSpawnPoints")] List<Transform> _enemiesSpawnPoints;
        private Vector3 StartPlayerAngle { get; } = new Vector3(0, 135f, 0);

        public void Initialize()
        {
            Debug.Log("Game started");
            SpawnPlayerShip(Vector3.zero, Quaternion.Euler(StartPlayerAngle));
            SpawnEnemiesShips();
        }

        private void SpawnEnemiesShips()
        {
            int enemieIndex = 0;
            foreach (var spawnPoint in _enemiesSpawnPoints)
            {
                var shipPresenter = new ShipPresenter($"Enemie-{enemieIndex++}", 
                    100f, 
                    1.3f, 
                    1f, 
                    _timerService);
                var shipView = _shipFactory.Create(spawnPoint.position, 
                    Quaternion.identity, 
                    shipPresenter);
                var enemyPresenter = new EnemyShipPresenter(shipPresenter);

                shipPresenter.OnDeath += ClaimPlayerReward;
            }
        }

        private void ClaimPlayerReward()
        {
            _giveMoneyUseCase.Execute(Random.Range(100, 250));
        }

        private void SpawnPlayerShip(Vector3 position,
            Quaternion rotation)
        {
            var shipView = _shipFactory.Create(position, rotation, _playerPresenter.ShipMovementPresenter);
            _playerPresenter.InitializePlayer(shipView.transform);
        }
    }
}