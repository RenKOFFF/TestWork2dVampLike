using UnityEngine;

namespace _Game.Scripts
{
    public class MonsterHealthComponent : HealthComponent
    {
        private void Start()
        {
            _health = GetComponent<Monster>().Stats.Health;
            _currentHealthComponent = MaxHealth;
        }
    }
}