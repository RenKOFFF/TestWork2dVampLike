using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts
{
    public class Monster : MonoBehaviour, IDamageable, ICreature
    {
        [SerializeField] private MonsterStats _stats;

        private MonsterHealthComponent _healthComponent;

        public Stats Stats => _stats;
        public MonsterHealthComponent HealthComponent => _healthComponent; 
        public event Action OnTakeDamageEvent;

        private void Start()
        {
            _healthComponent = GetComponent<MonsterHealthComponent>();
            _healthComponent.OnDeadEvent += Dead;
        }
        
        private void OnDisable()
        {
            HealthComponent.OnDeadEvent -= Dead;
        }

        private void Dead()
        {
            Debug.Log("PomerMonster");
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            var hero = col.GetComponent<Hero>();

            if (hero)
            {
                Debug.Log($"{name}: Enter hero - {col.name}");
                StartCoroutine(Attack(hero, hero.Stats.Damage));
            }
        }

        private IEnumerator Attack(Hero hero, float damageValue)
        {
            while (true)
            {
                Debug.Log("EnemyStartAttack");
                hero.TakeDamage(damageValue);
                yield return new WaitForSeconds(Stats.DamageSpeed);
            }
        }

        public void TakeDamage(float damageValue)
        {
            Debug.Log($"{name} taked pizdi");
            HealthComponent.DecreaseHealth(damageValue);
            OnTakeDamageEvent?.Invoke();
        }
    }
}