using System.Threading.Tasks;
using Game.Scripts.Infrastructure;
using Game.Scripts.Infrastructure.TimerService;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay.PresentersLayer.Wind
{
    public class WindPresenter : IWindPresenter, IInitializable, ITimerHandler
    {
        public ReactiveProperty<float> WindAngle { get; } = new();
        public Vector3 Direction => new(Mathf.Sin(AngleRadians), 0, Mathf.Sin(AngleRadians));
        private float AngleRadians => WindAngle.Value * Mathf.Deg2Rad;

        private readonly ITimerService _timerService;

        public WindPresenter(ITimerService timerService)
        {
            _timerService = timerService;
        }

        public async void Initialize()
        {
            await ChangeWindAngle();
        }

        private async Task ChangeWindAngle()
        {
            var from = WindAngle.Value;
            var to = Random.Range(0, 360);
            var duration = Random.Range(0.8f, 1.2f);
            await DoVirtualExtensions.FloatAsync(from, to, duration, windAngle => { WindAngle.Value = windAngle; });
            _timerService.SetupTimer(Random.Range(10, 20), this);
        }

        public async void HandleTimer()
        {
            await ChangeWindAngle();
        }
    }
}