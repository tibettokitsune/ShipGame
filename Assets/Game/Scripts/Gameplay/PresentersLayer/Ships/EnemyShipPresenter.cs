namespace Game.Scripts.Gameplay.PresentersLayer.Ships
{
    public class EnemyShipPresenter
    {
        private readonly ShipPresenter _shipPresenter;

        public EnemyShipPresenter(ShipPresenter shipPresenter)
        {
            _shipPresenter = shipPresenter;
        }
    }
}