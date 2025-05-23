using Game.Scripts.Gameplay.PresentersLayer;
using UniRx;
using UnityEngine;
using Zenject;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace Game.Scripts.Gameplay.ViewsLayer
{
    [RequireComponent(typeof(Rigidbody))]
    public class ShipView : MonoBehaviour
    {
        [Inject] private IWindPresenter _windPresenter;
        [SerializeField] private ShipSail shipSail;
        [SerializeField] private ShootingView shootingView;
        [SerializeField] private TakeDamageView takeDamageView;

        private Rigidbody Rigidbody
        {
            get
            {
                if (!_rigidbody)
                {
                    _rigidbody = GetComponent<Rigidbody>();
                }

                return _rigidbody;
            }
        }

        private ShipPresenter _shipPresenter;
        private Rigidbody _rigidbody;

        public void Initialize(Vector3 position, Quaternion rotation, ShipPresenter shipPresenter)
        {
            transform.position = position;
            transform.rotation = rotation;
            _shipPresenter = shipPresenter;
            takeDamageView.Setup(shipPresenter);
            shootingView.Setup(shipPresenter);
            _shipPresenter.SailPower.Subscribe(OnSailChange).AddTo(this);
        }

        private void Start()
        {
            Rigidbody.maxAngularVelocity = 1f;
            Rigidbody.maxLinearVelocity = 3f;
        }

        private void OnSailChange(float power)
        {
            shipSail.LerpSail(power);
        }

        private void FixedUpdate()
        {
            ProcessForwardMovement();
            ProcessRotationMovement();
        }

        private void ProcessRotationMovement()
        {
            Rigidbody.AddTorque(new Vector3(0, _shipPresenter.RotationPower, 0), ForceMode.Force);
        }

        private void ProcessForwardMovement()
        {
            if (_shipPresenter.SailPower.Value <= 0) return;
            var direction = transform.forward.normalized;
            var angleToWind = Vector3.Angle(direction, _windPresenter.Direction);
            var windEffect = angleToWind < 25? 1f : angleToWind < 90? 0.5f : 0.1f;
            Rigidbody.AddForce(direction * (_shipPresenter.SailPower.Value * windEffect), ForceMode.Force);
        }
    }
}