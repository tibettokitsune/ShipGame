using UniRx;
using UnityEngine;

namespace Game.Scripts.Gameplay.PresentersLayer
{
    public interface IPlayerPresenter
    {
        IReactiveProperty<int> Coins { get; }
        ShipPresenter ShipMovementPresenter { get; }
        void InitializePlayer(Transform transform);
    }
}