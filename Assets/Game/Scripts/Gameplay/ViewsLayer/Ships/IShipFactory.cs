using Game.Scripts.Gameplay.PresentersLayer.Ships;
using UnityEngine;

namespace Game.Scripts.Gameplay.ViewsLayer.Ships
{
    public interface IShipFactory
    {
        ShipView Create(Vector3 position, Quaternion rotation, ShipPresenter shipPresenter);
    }
}