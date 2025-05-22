using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay.ViewsLayer
{
    public class ViewsLayerInstaller : MonoInstaller
    {
        [SerializeField] private ShipView _shipPrefab;
        [SerializeField] private Transform _shipsParent;
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
        }
    }
}