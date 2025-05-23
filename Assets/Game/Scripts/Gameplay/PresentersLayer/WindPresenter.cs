using System.Threading.Tasks;
using DG.Tweening;
using Game.Scripts.Infrastructure.TimerService;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay.PresentersLayer
{
    public class WindPresenter : IWindPresenter, IInitializable, ITimerHandler
    {
        private readonly ITimerService _timerService;

        public WindPresenter(ITimerService timerService)
        {
            _timerService = timerService;
        }

        public ReactiveProperty<float> WindAngle { get; } = new();
        public Vector3 Direction => new Vector3(Mathf.Sin(AngleRadians), 0, Mathf.Sin(AngleRadians));
        private float AngleRadians => WindAngle.Value * Mathf.Deg2Rad;
        public async void Initialize()
        {
            await ChangeWindAngle();
        }

        private async Task ChangeWindAngle()
        {
            Debug.Log($"Wind Angle Change {WindAngle.Value}");
            var from = WindAngle.Value;
            var to = Random.Range(0, 360);
            var duration = Random.Range(0.8f, 1.2f);
            await DOVirtualExtensions.FloatAsync(from, to, duration, windAngle =>
            {
                WindAngle.Value = windAngle;
            });
            _timerService.SetupTimer(Random.Range(10, 20), this);
            Debug.Log($"Wind Angle Change {WindAngle.Value}");
        }

        public async void HandleTimer()
        {
            await ChangeWindAngle();
        }
    }
    
    public static class DOVirtualExtensions
    {
        public static Task FloatAsync(float from, float to, float duration, System.Action<float> onUpdate)
        {
            var tcs = new TaskCompletionSource<bool>();
        
            DOVirtual.Float(from, to, duration, windAngle =>
                {
                    onUpdate?.Invoke(windAngle);
                })
                .OnComplete(() => tcs.SetResult(true));
        
            return tcs.Task;
        }
    }
}