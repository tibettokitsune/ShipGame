namespace Game.Scripts.Gameplay.PresentersLayer
{
    public interface IMovementPresenter
    {
        void Rotate(float deltaAngle);
        void SailMode(float value);
    }
}