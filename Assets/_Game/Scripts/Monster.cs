using System;
using _Game.Scripts.Components;
using _Game.Scripts.Interfaces;
using UnityEngine;

namespace _Game.Scripts
{
    public class Monster : MonoBehaviour, IDamageable, ICreature
    {
        [SerializeField] private MonsterStats _stats;

        public Stats Stats => _stats;
        public HealthComponent<Monster> HealthComponent { get; private set; }
        public event Action<IDamageable> OnTakeDamageEvent;

        private void Start()
        {
            HealthComponent = GetComponent<HealthComponent<Monster>>();
            HealthComponent.OnDeadEvent += Dead;
        }

        private void Dead()
        {
            HealthComponent.OnDeadEvent -= Dead;
            StopAllCoroutines();
            Destroy(gameObject);
        }

        public void TakeDamage(IDamageable sender, float damageValue)
        {
            HealthComponent.DecreaseHealth(damageValue);
            OnTakeDamageEvent?.Invoke(sender);
        }
    }
}