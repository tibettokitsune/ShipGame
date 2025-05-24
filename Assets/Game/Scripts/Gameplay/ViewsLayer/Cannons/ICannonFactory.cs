using UnityEngine;

namespace Game.Scripts.Gameplay.ViewsLayer.Cannons
{
    public interface ICannonFactory
    {
        CannonView Create(Vector3 position, Transform target, float shooterPresenterShootingDamage,
            string shooterPresenterID);
    }
}