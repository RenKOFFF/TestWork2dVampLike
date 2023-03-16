using System;
using UnityEngine;

namespace _Game.Scripts
{
    public class HeroHealthComponent : HealthComponent
    {
        private void Start()
        {
            _health = GetComponent<Hero>().HeroData.Stats.Health;
            _currentHealthComponent = _health;
        }
    }
}