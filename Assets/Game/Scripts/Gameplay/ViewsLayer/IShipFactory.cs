using Game.Scripts.Gameplay.PresentersLayer;
using UnityEngine;

namespace Game.Scripts.Gameplay.ViewsLayer
{
    public interface IShipFactory
    {
        ShipView Create(Vector3 position, Quaternion rotation, UnitPresenter shipPresenter);
    }
}