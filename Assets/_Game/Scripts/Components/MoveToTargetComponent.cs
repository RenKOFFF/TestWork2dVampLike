using System;
using Unity.VisualScripting;
using UnityEngine;

namespace _Game.Scripts
{
    public class MoveToTargetComponent : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 1f;

        private GameObject _target;

        private void Start()
        {
            var monsterStats = GetComponent<Monster>().Stats as MonsterStats;
            _moveSpeed = monsterStats.MoveSpeed;
            _target = GameManager.Hero.gameObject;
        }

        private void Update()
        {
            if (_target == null) return;
            
            var currentPosition = transform.position;
            
            currentPosition = Vector2.MoveTowards(
                currentPosition,
                _target.transform.position - currentPosition,
                _moveSpeed * Time.deltaTime);
            transform.position = currentPosition;
        }
    }
}