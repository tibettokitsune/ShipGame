using Zenject;

namespace Game.Scripts.Gameplay.PresentersLayer
{
    public class EnemyShipPresenter : ITickable
    {
        private readonly ShipPresenter _shipPresenter;

        public EnemyShipPresenter(ShipPresenter shipPresenter)
        {
            _shipPresenter = shipPresenter;
        }

        public void Tick()
        {
            _shipPresenter.SailMode(1f);
        }
    }
}