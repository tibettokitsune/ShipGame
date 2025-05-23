using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay.ViewsLayer
{
    public class ViewsLayerInstaller : MonoInstaller
    {
        [SerializeField] private ShipView _shipPrefab;
        [SerializeField] private Transform _shipsParent;
        [SerializeField] private CannonView _cannonPrefab;
        [SerializeField] private Transform _cannonsParent;
        [SerializeField] private List<Transform> enemiesSpawnPoints;
        public override void InstallBindings()
        {
            Container.Bind<ShipView>()
                .WithId("ShipPrefab")
                .FromInstance(_shipPrefab)
                .AsTransient();
            
            Container.Bind<Transform>()
                .WithId("ShipsParent")
                .FromInstance(_shipsParent);
            
            Container.Bind<IShipFactory>()
                .To<ShipFactory>()
                .AsSingle();
            
            Container.Bind<CannonView>()
                .WithId("CannonPrefab")
                .FromInstance(_cannonPrefab)
                .AsTransient();
            
            Container.Bind<Transform>()
                .WithId("CannonsParent")
                .FromInstance(_shipsParent);
            
            Container.Bind<ICannonFactory>()
                .To<CannonFactory>()
                .AsSingle();
            
            Container.Bind<List<Transform>>()
                .WithId("EnemiesSpawnPoints")
                .FromInstance(enemiesSpawnPoints);
        }
    }
}