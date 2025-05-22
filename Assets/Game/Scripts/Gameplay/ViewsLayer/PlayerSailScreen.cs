using Game.Scripts.Gameplay.PresentersLayer;
using Game.Scripts.Infrastructure.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Scripts.Gameplay.ViewsLayer
{
    public class PlayerSailScreen : UIScreen
    {
        [SerializeField] private Slider sailSlider;
        [Inject] private ISailPowerChangeUseCase _sailPowerChangeUseCase;

        private void Start()
        {
            sailSlider.onValueChanged.AddListener(OnSailPowerChanged);   
        }

        private void OnSailPowerChanged(float sailPower) => _sailPowerChangeUseCase.Execute(sailPower);
    }
}