using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.Scripts.Gameplay.ViewsLayer
{
    [RequireComponent(typeof(RectTransform))]
    public class WheelWidget : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        [Header("Rotation Settings")] [Range(-180, 0)]
        public float minAngle = -150f;

        [Range(0, 180)] public float maxAngle = 150f;
        public float rotationSensitivity = 1f;

        [Header("Visual")] public Image wheelImage;

        private RectTransform rectTransform;
        private float currentAngle;

        public float Value => Mathf.Clamp(currentAngle / Mathf.Max(Mathf.Abs(minAngle), Mathf.Abs(maxAngle)), -1f, 1f);

        private bool _isDragging;
        private const float Threshold = 0.05f;
        private const float ReturnSpeed = 15f;
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            if (wheelImage == null) wheelImage = GetComponent<Image>();
            currentAngle = 0f;
            UpdateRotation();
        }

        public void OnDrag(PointerEventData eventData)
        {
            var rotationAmount = eventData.delta.x * rotationSensitivity;
            currentAngle += rotationAmount;

            currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle);

            UpdateRotation();
        }

        private void UpdateRotation()
        {
            rectTransform.localEulerAngles = new Vector3(0, 0, -currentAngle);
        }

        public void OnBeginDrag(PointerEventData eventData) => _isDragging = true;

        public void OnEndDrag(PointerEventData eventData) => _isDragging = false;

        private void Update()
        {
            if (_isDragging || !(Mathf.Abs(Value) > 0f)) return;
            var deltaAngle = Time.deltaTime * ReturnSpeed;
            if(currentAngle < 0) deltaAngle = -deltaAngle;
                
            currentAngle -= deltaAngle;
            if (Mathf.Abs(currentAngle) < Threshold)
            {
                currentAngle = 0f;
            }
            UpdateRotation();
        }
    }
}