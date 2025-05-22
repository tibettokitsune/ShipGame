namespace Game.Scripts.Gameplay.PresentersLayer
{
    public class UnitPresenter : IUnitPresenter
    {
        public void Rotate(float deltaAngle)
        {
            throw new System.NotImplementedException();
        }

        public void SailMode(float value)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IUnitPresenter
    {
        void Rotate(float deltaAngle);
        void SailMode(float value);
    }
}