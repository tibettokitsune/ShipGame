using System;
using System.Collections.Generic;
using System.Linq;
using Game.Scripts.Gameplay.PresentersLayer;
using UnityEngine;

namespace Game.Scripts.Gameplay.ViewsLayer
{
    [RequireComponent(typeof(SphereCollider))]
    public class ShootingView : MonoBehaviour
    {
        [SerializeField] private SphereCollider targetTrigger;
        private IShooterPresenter _shooterPresenter;
        [SerializeField] private List<TakeDamageView> targets = new();
        [SerializeField] private ParticleSystem cannonEffect;
        public bool IsAnyTargets => targets.Count > 0;
        public TakeDamageView ClosestTarget => targets
            .OrderBy(target => Vector3.Distance(transform.position, target.transform.position))
            .FirstOrDefault();
        private void OnValidate()
        {
            if (targetTrigger == null)
                targetTrigger = GetComponent<SphereCollider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var target = other.GetComponent<TakeDamageView>();
            if (target != null)
            {
                if (targets.Count <= 0) _shooterPresenter.NotifyTargetFound();
                targets.Add(target);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var target = other.GetComponent<TakeDamageView>();
            if (target == null) return;
            if (targets.Contains(target))
                targets.Remove(target);

            if (targets.Count == 0) _shooterPresenter.NotifyTargetLost();
        }

        public void Setup(IShooterPresenter shooterPresenter)
        {
            _shooterPresenter = shooterPresenter;
            _shooterPresenter.OnShoot += Shoot;
        }

        private void Shoot()
        {
            var dir = ClosestTarget.transform.position - transform.position;
            cannonEffect.transform.rotation = Quaternion.LookRotation(dir);
            cannonEffect.Play();
        }

        private void OnDestroy()
        {
            _shooterPresenter.OnShoot -= Shoot;
        }
    }
}