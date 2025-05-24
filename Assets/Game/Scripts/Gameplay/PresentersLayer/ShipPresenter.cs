using System;
using Game.Scripts.Infrastructure.TimerService;
using UniRx;

namespace Game.Scripts.Gameplay.PresentersLayer
{
    public class ShipPresenter : IMovementPresenter, ITakingDamagePresenter, IShooterPresenter, ITimerHandler
    {
        private readonly ITimerService _timerService;
        public event Action OnDeath;
        public event Action OnShoot;
        private event Action OnTargetFounded;
        private event Action OnTargetLost;
        public ReactiveProperty<float> Hp { get; } = new();
        public ReactiveProperty<float> SailPower { get; } = new();

        public string ID { get; }
        public float RotationPower { get; private set; }
        public float ShootingCooldown { get; }
        public float ShootingDamage { get; }
        public void NotifyTargetFound() => OnTargetFounded?.Invoke();

        public void NotifyTargetLost() => OnTargetLost?.Invoke();

        private float MaxHp { get; }

        private string _timerId;

        public ShipPresenter(string id,
            float hpLimit,
            float shootingCooldown,
            float shootingDamage,
            ITimerService timerService)
        {
            _timerService = timerService;
            ID = id;
            MaxHp = hpLimit;
            ShootingCooldown = shootingCooldown;
            ShootingDamage = shootingDamage;
            Hp.Value = MaxHp;

            OnTargetFounded += OnTargetFoundedSetup;
            OnTargetLost += OnTargetLostSetup;
        }

        private void OnTargetLostSetup()
        {
            _timerService.Remove(_timerId);
        }

        private void OnTargetFoundedSetup() => _timerId = _timerService.SetupTimer(ShootingCooldown, this);

        public void Rotate(float rotationPower) => RotationPower = rotationPower;

        public void SailMode(float value) => SailPower.Value = value;

        public void TakeDamage(float damage, string source)
        {
            if (Hp.Value - damage < 0) damage = Hp.Value;

            Hp.Value -= damage;

            if (Hp.Value <= 0) OnDeath?.Invoke();
        }

        public void HandleTimer() => Shoot();

        private void Shoot()
        {
            OnShoot?.Invoke();
            _timerId = _timerService.SetupTimer(ShootingCooldown, this);
        }
    }

    public interface IShooterPresenter
    {
        public string ID { get; }
        event Action OnShoot;
        public float ShootingCooldown { get; }
        public float ShootingDamage { get; }
        void NotifyTargetFound();
        void NotifyTargetLost();
    }
}