using System;
using System.Collections;
using _Game.Scripts.Interfaces;
using Unity.VisualScripting;
using UnityEngine;

namespace _Game.Scripts.Components
{
    public class CombatComponent : MonoBehaviour
    {
        
        [SerializeField] private CircleCollider2D _attackCollider;
        [SerializeField] private float _attackRange;

        private ICreature _сreature;
        
        private IDamageable _oldTarget;
        private IDamageable _currentTarget;
        public event Action<IDamageable> OnTargetSwitchedEvent; 

        public float AttackCooldown { get; private set; }

        private void Start()
        {
            AttackCooldown = GetComponent<ICreature>().Stats.DamageSpeed;
            _attackCollider.radius = _attackRange;
            
            _currentTarget = GameManager.Hero;
            OnTargetSwitchedEvent?.Invoke(_currentTarget);
            
            _сreature = GetComponent<ICreature>();
            if (_сreature is IDamageable damageableCreature)
            {
                damageableCreature.OnTakeDamageEvent += ChangeTarget;
            } 
        }

        private void ChangeTarget(IDamageable newAttackTarget)
        {
            _oldTarget = _currentTarget;
            _currentTarget = newAttackTarget;
            OnTargetSwitchedEvent?.Invoke(_currentTarget);
            
        }

        private void TryReturnToOldTarget()
        {
            if (_oldTarget != null)
            {
                _currentTarget = _oldTarget;
                OnTargetSwitchedEvent?.Invoke(_currentTarget);
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            var target = col.GetComponent<IDamageable>();
            
            if (target == _currentTarget)
            {
                StartCoroutine(Attack(target, _сreature.Stats.Damage));
            }
        }

        private IEnumerator Attack(IDamageable damageable, float damageValue)
        {
            while (true)
            {
                if (damageable == null)
                {
                    TryReturnToOldTarget();
                    yield break;
                }
                
                damageable.TakeDamage(_сreature as IDamageable, damageValue);
                yield return new WaitForSeconds(_сreature.Stats.DamageSpeed);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(transform.position, _attackRange);
        }
        
        
    }
}