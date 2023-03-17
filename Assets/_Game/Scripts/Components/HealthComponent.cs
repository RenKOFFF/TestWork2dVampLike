using System;
using UnityEngine;

namespace _Game.Scripts
{
    public abstract class HealthComponent<T> : MonoBehaviour where T : ICreature
    {
        protected float _currentHealthComponent;

        public float MaxHealth { get; private set; }

        public event Action<float> OnHealthValueChangedEvent; 
        public event Action OnDeadEvent;

        private void Start()
        {
            MaxHealth = GetComponent<T>().Stats.Health;
            _currentHealthComponent = MaxHealth;
        }

        public void DecreaseHealth(float damageValue)
        {
            _currentHealthComponent -= damageValue;
            Debug.Log($"{name} health is{_currentHealthComponent}");

            if (_currentHealthComponent <= 0)
            {
                OnDeadEvent?.Invoke();
            }
            
            OnHealthValueChangedEvent?.Invoke(_currentHealthComponent);
        }
        
        public void IncreaseHealth(float healValue)
        {
            _currentHealthComponent += healValue;
            OnHealthValueChangedEvent?.Invoke(_currentHealthComponent);
        }
    }
}