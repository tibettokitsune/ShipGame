using UniRx;
using UnityEngine;

namespace Game.Scripts.Gameplay.DataLayer.Wind
{
    public interface IWindDataProvider
    {
        ReactiveProperty<Vector2> WindDirection { get; }
    }
}