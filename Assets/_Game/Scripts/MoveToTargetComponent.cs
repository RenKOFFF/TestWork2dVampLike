﻿using System;
using UnityEngine;

namespace _Game.Scripts
{
    public class MoveToTargetComponent : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 5f;

        private Hero _target;

        private void Start()
        {
            _target = GameManager.Hero;
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