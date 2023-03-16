using UnityEngine;

namespace _Game.Scripts
{
    [CreateAssetMenu(fileName = "HeroData", menuName = "Hero/new HeroData", order = 1)]
    public class HeroData : ScriptableObject
    {
        [SerializeField] private HeroStats _stats;
        public HeroStats Stats => _stats;
    }
}