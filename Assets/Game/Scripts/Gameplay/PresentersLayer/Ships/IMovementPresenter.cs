namespace Game.Scripts.Gameplay.PresentersLayer.Ships
{
    public interface IMovementPresenter
    {
        void Rotate(float deltaAngle);
        void SailMode(float value);
    }
}