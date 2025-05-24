using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.Scripts.Gameplay.ViewsLayer.UI
{
    [RequireComponent(typeof(RectTransform))]
    public class WheelWidget : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        [SerializeField, Range(-180, 0)] private float minAngle = -150f;
        [SerializeField, Range(0, 180)] private float maxAngle = 150f;
        [SerializeField] private float rotationSensitivity = 1f;
        [SerializeField] private Image wheelImage;

        public float Value => Mathf.Clamp(_currentAngle / Mathf.Max(Mathf.Abs(minAngle), Mathf.Abs(maxAngle)), -1f, 1f);

        private RectTransform _rectTransform;
        private float _currentAngle;
        private bool _isDragging;
        private const float Threshold = 0.05f;
        private const float ReturnSpeed = 15f;
        
        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            if (wheelImage == null) wheelImage = GetComponent<Image>();
            _currentAngle = 0f;
            UpdateRotation();
        }

        public void OnDrag(PointerEventData eventData)
        {
            var rotationAmount = eventData.delta.x * rotationSensitivity;
            _currentAngle += rotationAmount;

            _currentAngle = Mathf.Clamp(_currentAngle, minAngle, maxAngle);

            UpdateRotation();
        }

        private void UpdateRotation()
        {
            _rectTransform.localEulerAngles = new Vector3(0, 0, -_currentAngle);
        }

        public void OnBeginDrag(PointerEventData eventData) => _isDragging = true;

        public void OnEndDrag(PointerEventData eventData) => _isDragging = false;

        private void Update()
        {
            if (_isDragging || !(Mathf.Abs(Value) > 0f)) return;
            var deltaAngle = Time.deltaTime * ReturnSpeed;
            if(_currentAngle < 0) deltaAngle = -deltaAngle;
                
            _currentAngle -= deltaAngle;
            if (Mathf.Abs(_currentAngle) < Threshold)
            {
                _currentAngle = 0f;
            }
            UpdateRotation();
        }
    }
}