using System;
using _Game.Scripts.Components;
using _Game.Scripts.Interfaces;
using Unity.VisualScripting;
using UnityEngine;

namespace _Game.Scripts
{
    public class MoveToTargetComponent : MonoBehaviour
    {
        private CombatComponent _combatComponent;
        
        private float _moveSpeed = 1f;
        private Transform _target;

        private void Start()
        {
            _combatComponent = GetComponent<CombatComponent>();
            _combatComponent.OnTargetSwitchedEvent += ChangeTarget;
            
            var stats = GetComponent<ICreature>().Stats;
            if (stats is MonsterStats monsterStats)
                _moveSpeed = monsterStats.MoveSpeed;
            
            _target = GameManager.Hero.transform;
        }

        private void OnDestroy()
        {
            _combatComponent.OnTargetSwitchedEvent -= ChangeTarget;
        }

        private void ChangeTarget(IDamageable newTarget)
        {
            if (newTarget is Transform transformTarget)
            {
                _target = transformTarget ;
            }
        }

        private void Update()
        {
            if (_target == null) return;
            
            var currentPosition = transform.position;
            
            currentPosition = Vector2.MoveTowards(
                currentPosition,
                _target.position - currentPosition,
                _moveSpeed * Time.deltaTime);
            transform.position = currentPosition;
        }
    }
}