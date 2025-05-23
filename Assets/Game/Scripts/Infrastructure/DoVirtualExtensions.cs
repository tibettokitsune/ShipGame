using System.Threading.Tasks;
using DG.Tweening;

namespace Game.Scripts.Infrastructure
{
    public static class DoVirtualExtensions
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