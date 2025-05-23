using UniRx;
using UnityEngine;

namespace Game.Scripts.Gameplay.PresentersLayer
{
    public interface IWindPresenter
    {
        ReactiveProperty<float> WindAngle { get; }
        Vector3 Direction { get; }
    }
}