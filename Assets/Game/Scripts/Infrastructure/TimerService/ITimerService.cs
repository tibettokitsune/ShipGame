namespace Game.Scripts.Infrastructure.TimerService
{
    public interface ITimerService
    {
        void SetupTimer(float time, ITimerHandler handler);
    }
}