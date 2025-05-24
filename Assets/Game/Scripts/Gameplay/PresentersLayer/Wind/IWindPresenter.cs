using UniRx;
using UnityEngine;

namespace Game.Scripts.Gameplay.PresentersLayer.Wind
{
    public interface IWindPresenter
    {
        ReactiveProperty<float> WindAngle { get; }
        Vector3 Direction { get; }
    }
}