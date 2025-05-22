using UniRx;
using UnityEngine;

namespace Game.Scripts.Gameplay.DataLayer.Wind
{
    public class WindDataProvider : IWindDataProvider
    {
        public ReactiveProperty<Vector2> WindDirection { get; } = new ReactiveProperty<Vector2>();
    }
}