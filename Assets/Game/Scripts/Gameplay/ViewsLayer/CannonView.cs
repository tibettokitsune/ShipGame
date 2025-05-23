using System;
using UnityEngine;

namespace Game.Scripts.Gameplay.ViewsLayer
{
    public class CannonView : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private ParticleSystem contactEffect;
        private const float CannonForce = 50f;
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
            rigidbody.AddForce((target.position - transform.position).normalized * CannonForce, ForceMode.VelocityChange);
        }

        private void OnCollisionEnter(Collision other)
        {
            var contact = other.gameObject.GetComponent<TakeDamageView>();
            if (contact)
            {
                contact.TakeDamage(_ownerId, _damage);
            }

            Instantiate(contactEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}