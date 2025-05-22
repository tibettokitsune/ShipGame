using Game.Scripts.Gameplay.PresentersLayer;
using UniRx;
using UnityEngine;

namespace Game.Scripts.Gameplay.ViewsLayer
{
    [RequireComponent(typeof(Rigidbody))]
    public class ShipView : MonoBehaviour
    {
        private UnitPresenter _unitPresenter;
        [SerializeField] private ShipSail shipSail;

        public void Initialize(Vector3 position, Quaternion rotation, UnitPresenter shipPresenter)
        {
            transform.position = position;
            transform.rotation = rotation;
            _unitPresenter = shipPresenter;
            _unitPresenter.SailPower.Subscribe(OnSailChange).AddTo(this);
        }

        private void OnSailChange(float power)
        {
            shipSail.LerpSail(power);
        }

        public Rigidbody Rigidbody
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

        private Rigidbody _rigidbody;

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
            Rigidbody.AddForce(direction * _unitPresenter.SailPower.Value, ForceMode.Force);
        }
    }
}