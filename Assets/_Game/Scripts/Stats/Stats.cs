using System;

namespace _Game.Scripts
{
    [Serializable]
    public class Stats
    {
        public float Health, Damage, DamageSpeed;

        public Stats(float health, float damage, float damageSpeed)
        {
            Health = health;
            Damage = damage;
            DamageSpeed = damageSpeed;
        }
    }
}