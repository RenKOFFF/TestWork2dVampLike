using System;
using UnityEngine;

namespace _Game.Scripts.Interfaces
{
    public interface IDamageable
    {
        public event Action<IDamageable> OnTakeDamageEvent; 
        public void TakeDamage(IDamageable sender, float damageValue);
    
    }
}