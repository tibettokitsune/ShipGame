using UniRx;
using UnityEngine;

namespace Game.Scripts.Gameplay.PresentersLayer
{
    public interface IPlayerPresenter
    {
        ReactiveProperty<int> Coins { get; }
        ShipPresenter ShipMovementPresenter { get; }
        void InitializePlayer(Transform transform);
    }
}