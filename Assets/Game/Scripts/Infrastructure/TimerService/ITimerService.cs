namespace Game.Scripts.Infrastructure.TimerService
{
    public interface ITimerService
    {
        string SetupTimer(float time, ITimerHandler handler);
        void Remove(string timerId);
    }
}