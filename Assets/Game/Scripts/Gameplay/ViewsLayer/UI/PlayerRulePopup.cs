using Game.Scripts.Gameplay.PresentersLayer;
using Game.Scripts.Infrastructure.UI;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay.ViewsLayer.UI
{
    public class PlayerRulePopup : UIScreen
    {
        [SerializeField] private WheelWidget wheel;
        [Inject] private IRotationPowerChangeUseCase _rotationPowerChangeUseCase;
        private const float Threshold = 0.15f;

        private void Update()
        {
            if (Mathf.Abs(wheel.Value) < Threshold) _rotationPowerChangeUseCase.Execute(0f);
            else _rotationPowerChangeUseCase.Execute(wheel.Value);
        }
    }
}