namespace Game.Scripts.Infrastructure.Loading
{
    public class LoadingWrapper : ILoading
    {
        private readonly LoadingScreen _screen;

        public float Progress
        {
            get => _screen.Progress;
            set => _screen.Progress = value;
        }

        public LoadingWrapper(LoadingScreen screen)
        {
            _screen = screen;
            _screen.IncRef();
        }

        public void Dispose() => _screen.DecRef();
    }
}