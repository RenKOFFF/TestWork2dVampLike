using UnityEngine;

namespace _Game.Scripts
{
    [CreateAssetMenu(fileName = "OverridenMonsterData", menuName = "Monsters/new OverridenMonsterData", order = 1)]
    public class OverridenMonsterData : MonsterData
    {
        [SerializeField] private MonsterData _overrideSource;
        [SerializeField] private StatsCoefficient _statsCoefficient;
        

        public Stats Stats =>
            new (_overrideSource.Stats.Health * _statsCoefficient.HealthCoefficient,
                _overrideSource.Stats.Damage * _statsCoefficient.DamageCoefficient,
                _overrideSource.Stats.MoveSpeed * _statsCoefficient.MoveSpeedCoefficient,
                _overrideSource.Stats.DamageSpeed * _statsCoefficient.DamageSpeedCoefficient);
       
    }
}
