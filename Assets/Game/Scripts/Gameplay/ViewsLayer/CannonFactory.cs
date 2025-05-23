using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay.ViewsLayer
{
    public class CannonFactory : ICannonFactory
    {
        private readonly DiContainer _container;
        private readonly CannonView _prefab;
        private readonly Transform _parent;

        public CannonFactory(
            DiContainer container,
            [Inject(Id = "CannonPrefab")] CannonView prefab,
            [Inject(Id = "CannonsParent")] Transform parent)
        {
            _container = container;
            _prefab = prefab;
            _parent = parent;
        }

        public CannonView Create(Vector3 position, Transform target, 
            float shooterPresenterShootingDamage,
            string shooterPresenterID)
        {
            var cannon = _container.InstantiatePrefabForComponent<CannonView>(
                _prefab,
                position, 
                Quaternion.identity, 
                _parent);

            cannon.Initialize(target, shooterPresenterShootingDamage, shooterPresenterID);
            return cannon;
        }
    }
}