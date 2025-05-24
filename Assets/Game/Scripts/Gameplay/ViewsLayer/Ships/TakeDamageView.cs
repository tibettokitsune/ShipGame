using Game.Scripts.Gameplay.PresentersLayer.Ships;
using UnityEngine;
using UnityEngine.Playables;

namespace Game.Scripts.Gameplay.ViewsLayer.Ships
{
    public class TakeDamageView : MonoBehaviour
    {
        [SerializeField] private PlayableDirector deathDirector;
        [SerializeField] private Rigidbody rb;
        public string OwnerId => _takingDamagePresenter.ID;
        private ITakingDamagePresenter _takingDamagePresenter;

        private void OnValidate()
        {
            if(rb == null) rb = GetComponentInParent<Rigidbody>();
        }

        public void Setup(ITakingDamagePresenter takingDamagePresenter)
        {
            _takingDamagePresenter = takingDamagePresenter;
            _takingDamagePresenter.OnDeath += OnDeath;
        }

        private async void OnDeath()
        {
            rb.detectCollisions = false; 
            deathDirector.Play();
        }

        public void TakeDamage(string ownerId, float damage)
        {
            _takingDamagePresenter.TakeDamage(damage, ownerId);
        }

        private void OnDestroy()
        {
            _takingDamagePresenter.OnDeath -= OnDeath;
        }
    }
}