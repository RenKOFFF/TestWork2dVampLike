using UnityEngine;

namespace _Game.Scripts
{
    [CreateAssetMenu(fileName = "MonsterData", menuName = "Monsters/new MonsterData", order = 0)]
    public class MonsterData : ScriptableObject
    {
        [SerializeField] private Stats _stats;
        public Stats Stats => _stats;
    }
}