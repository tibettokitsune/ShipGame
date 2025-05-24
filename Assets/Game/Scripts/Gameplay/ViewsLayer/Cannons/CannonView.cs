using Game.Scripts.Gameplay.ViewsLayer.Ships;
using Game.Scripts.Infrastructure;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Scripts.Gameplay.ViewsLayer.Cannons
{
    public class CannonView : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private ParticleSystem contactEffect;
        private const float CannonForce = 30f;
        private float _damage;
        private string _ownerId;
        private void OnValidate()
        {
            if (rigidbody == null) rigidbody = GetComponent<Rigidbody>();
        }

        public void Initialize(Transform target, float damage, string ownerId)
        {
            _damage = damage;
            _ownerId = ownerId;
            
            var targetPositionWithError = target.position + Random.insideUnitSphere * 2f;
            rigidbody.linearVelocity = BallisticCalculator.CalculateTrajectoryVelocity(transform.position, 
                targetPositionWithError, 
                .5f);
        }

        private void OnTriggerEnter(Collider other)
        {
            var contact = other.gameObject.GetComponent<TakeDamageView>();
            if (contact)
            {
                if(contact.OwnerId.Equals(_ownerId)) return;
                contact.TakeDamage(_ownerId, _damage);
            }

            Instantiate(contactEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}