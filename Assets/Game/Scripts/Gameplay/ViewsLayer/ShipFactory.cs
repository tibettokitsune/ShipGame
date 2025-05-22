using Game.Scripts.Gameplay.PresentersLayer;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay.ViewsLayer
{
    public class ShipFactory : IShipFactory
    {
        private readonly DiContainer _container;
        private readonly ShipView _prefab;
        private readonly Transform _parent;

        public ShipFactory(
            DiContainer container,
            [Inject(Id = "ShipPrefab")] ShipView prefab,
            [Inject(Id = "ShipsParent")] Transform parent)
        {
            _container = container;
            _prefab = prefab;
            _parent = parent;
        }

        public ShipView Create(Vector3 position, Quaternion rotation, UnitPresenter shipPresenter)
        {
            var ship = _container.InstantiatePrefabForComponent<ShipView>(
                _prefab,
                position,
                rotation,
                _parent);

            ship.Initialize(position, rotation, shipPresenter);

            return ship;
        }
    }
}