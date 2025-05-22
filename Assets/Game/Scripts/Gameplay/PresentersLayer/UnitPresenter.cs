using Game.Scripts.Gameplay.DataLayer.Unit;
using UniRx;

namespace Game.Scripts.Gameplay.PresentersLayer
{
    public class UnitPresenter : IUnitPresenter
    {
        private UnitDataProvider _dataProvider;
        public ReactiveProperty<float> SailPower { get; private set; } = new();
        public float RotationPower { get; private set; }

        public void Rotate(float rotationPower) => RotationPower = rotationPower;

        public void SailMode(float value) => SailPower.Value = value;
    }
}