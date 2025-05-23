using UnityEngine;

namespace Game.Scripts.Gameplay.ViewsLayer
{
    public interface ICannonFactory
    {
        CannonView Create(Vector3 position, Transform target, float shooterPresenterShootingDamage,
            string shooterPresenterID);
    }
}