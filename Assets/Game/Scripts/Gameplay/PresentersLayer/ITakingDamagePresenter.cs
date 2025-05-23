using System;
using UniRx;

namespace Game.Scripts.Gameplay.PresentersLayer
{
    public interface ITakingDamagePresenter
    {
        public event Action OnDeath;
        public string ID { get; }
        public ReactiveProperty<float> Hp { get; }
        public void TakeDamage(float damage, string source);
    }
}