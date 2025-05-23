using Game.Scripts.Gameplay.PresentersLayer;
using Game.Scripts.Infrastructure.UI;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Scripts.Gameplay.ViewsLayer
{
    public class HUDScreen : UIScreen
    {
        [Inject] private IWindPresenter _windPresenter;
        [SerializeField] private RectTransform windArrow;

        private void Start()
        {
            _windPresenter.WindAngle.Subscribe(OnWindAngleChanged).AddTo(this);
        }

        private void OnWindAngleChanged(float angle)
        {
            windArrow.eulerAngles = new Vector3(windArrow.eulerAngles.x, windArrow.eulerAngles.y, angle);
        }
    }
}