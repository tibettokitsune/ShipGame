using Game.Scripts.Gameplay.PresentersLayer;
using Game.Scripts.Infrastructure;
using Game.Scripts.Infrastructure.UI;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay.ViewsLayer.UI
{
    public class HUDScreen : UIScreen
    {
        [Inject] private IWindPresenter _windPresenter;
        [Inject] private IPlayerPresenter _playerPresenter;
        [SerializeField] private RectTransform windArrow;
        [SerializeField] private TextMeshProUGUI coinsLbl;
        private int _cashCoinsNumber;
        private void Start()
        {
            _windPresenter.WindAngle.Subscribe(OnWindAngleChanged).AddTo(this);
            _playerPresenter.Coins.Subscribe(OnCoinsChange).AddTo(this);
        }

        private async void OnCoinsChange(int newValue)
        {
            await DoVirtualExtensions.FloatAsync(_cashCoinsNumber, newValue, 1f, coinValue =>
            {
                coinsLbl.text = coinValue.ToString("F0");
            });
            coinsLbl.text = $"{newValue}";
            _cashCoinsNumber = newValue;
        }

        private void OnWindAngleChanged(float angle)
        {
            windArrow.eulerAngles = new Vector3(windArrow.eulerAngles.x, windArrow.eulerAngles.y, angle);
        }
    }
}