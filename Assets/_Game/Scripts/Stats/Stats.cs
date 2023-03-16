using System;

namespace _Game.Scripts
{
    [Serializable]
    public struct Stats
    {
        public float Health, Damage, MoveSpeed, DamageSpeed;
        
        public Stats(float health, float damage, float moveSpeed, float damageSpeed)
        {
            Health = health;
            Damage = damage;
            MoveSpeed = moveSpeed;
            DamageSpeed = damageSpeed;
        }
    }
}