using System;

namespace _Game.Scripts
{
    [Serializable]
    public class MonsterStats : Stats
    {
        public float MoveSpeed;

        public MonsterStats(float health, float damage, float moveSpeed, float damageSpeed) : base(health, damage, damageSpeed)
        {
            MoveSpeed = moveSpeed;
        }
    }
}