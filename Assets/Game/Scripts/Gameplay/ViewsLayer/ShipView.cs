using System.Numerics;
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

        private UnitPresenter _unitPresenter;
        private Rigidbody _rigidbody;

        public void Initialize(Vector3 position, Quaternion rotation, UnitPresenter shipPresenter)
        {
            transform.position = position;
            transform.rotation = rotation;
            _unitPresenter = shipPresenter;
            _unitPresenter.SailPower.Subscribe(OnSailChange).AddTo(this);
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
            Rigidbody.AddTorque(new Vector3(0, _unitPresenter.RotationPower, 0), ForceMode.Force);
        }

        private void ProcessForwardMovement()
        {
            if (_unitPresenter.SailPower.Value <= 0) return;
            var direction = transform.forward.normalized;
            var angleToWind = Vector3.Angle(direction, _windPresenter.Direction);
            var windEffect = angleToWind < 25? 1f : angleToWind < 90? 0.5f : 0.1f;
            Rigidbody.AddForce(direction * (_unitPresenter.SailPower.Value * windEffect), ForceMode.Force);
        }
    }
}