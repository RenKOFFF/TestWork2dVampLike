using UnityEngine;

namespace _Game.Scripts
{
    public class MonsterHealthComponent : HealthComponent
    {
        private void Start()
        {
            _health = GetComponent<Monster>().MonsterData.Stats.Health;
            _currentHealthComponent = MaxHealth;
        }
    }
}