using UniRx;
using UnityEngine;

namespace Game.Scripts.Gameplay.PresentersLayer.Ships
{
    public interface IPlayerPresenter
    {
        IReactiveProperty<int> Coins { get; }
        ShipPresenter ShipMovementPresenter { get; }
        void InitializePlayer(Transform transform);
    }
}