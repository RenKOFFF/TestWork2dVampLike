using System;

namespace _Game.Scripts
{
    [Serializable]
    public struct HeroStats
    {
        public float Health, Damage, DamageSpeed;

        public HeroStats(float health, float damage, float damageSpeed)
        {
            Health = health;
            Damage = damage;
            DamageSpeed = damageSpeed;
        }
    }
}