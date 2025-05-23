using Game.Scripts.Gameplay.PresentersLayer;
using UnityEngine;

namespace Game.Scripts.Gameplay.ViewsLayer
{
    public class TakeDamageView : MonoBehaviour
    {
        private ITakingDamagePresenter _takingDamagePresenter;

        public void Setup(ITakingDamagePresenter takingDamagePresenter)
        {
            _takingDamagePresenter = takingDamagePresenter;
        }

        public void TakeDamage(string ownerId, float damage)
        {
            _takingDamagePresenter.TakeDamage(damage, ownerId);
        }
    }
}