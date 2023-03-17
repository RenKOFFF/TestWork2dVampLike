using System;
using System.Collections;
using _Game.Scripts.Components;
using UnityEngine;

namespace _Game.Scripts
{
    public class Monster : MonoBehaviour, IDamageable, ICreature
    {
        [SerializeField] private MonsterStats _stats;

        public Stats Stats => _stats;
        public HealthComponent<Monster> HealthComponent { get; private set; }
        public event Action OnTakeDamageEvent;

        private void Start()
        {
            HealthComponent = GetComponent<HealthComponent<Monster>>();
            HealthComponent.OnDeadEvent += Dead;
        }

        private void OnDisable()
        {
            HealthComponent.OnDeadEvent -= Dead;
        }

        private void Dead()
        {
            StopAllCoroutines();
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            var hero = col.GetComponent<Hero>();

            if (hero)
            {
                StartCoroutine(Attack(hero, hero.Stats.Damage));
            }
        }

        private IEnumerator Attack(Hero hero, float damageValue)
        {
            while (true)
            {
                hero.TakeDamage(damageValue);
                yield return new WaitForSeconds(Stats.DamageSpeed);
            }
        }

        public void TakeDamage(float damageValue)
        {
            HealthComponent.DecreaseHealth(damageValue);
            OnTakeDamageEvent?.Invoke();
        }
    }
}