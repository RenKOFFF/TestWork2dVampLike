using System;

namespace _Game.Scripts
{
    [Serializable]
    public struct StatsCoefficient
    {
        public float HealthCoefficient, DamageCoefficient, MoveSpeedCoefficient, DamageSpeedCoefficient;
        
        public StatsCoefficient(float healthCoefficient, float damageCoefficient, float moveSpeedCoefficient, float damageSpeedCoefficient)
        {
            HealthCoefficient = healthCoefficient;
            DamageCoefficient = damageCoefficient;
            MoveSpeedCoefficient = moveSpeedCoefficient;
            DamageSpeedCoefficient = damageSpeedCoefficient;
        }
    }
}