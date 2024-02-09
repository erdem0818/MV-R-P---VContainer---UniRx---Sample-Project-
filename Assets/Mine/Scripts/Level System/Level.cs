using UnityEngine;
using NaughtyAttributes;

namespace Assets.Mine.Scripts.LevelSystem
{
    [CreateAssetMenu(menuName = "Data/Level Data", fileName = "Level Data")]
    public class Level : ScriptableObject
    {        
        [Header("Grid Settings")]
        [HorizontalLine(color: EColor.Blue)]
        [MinValue(2)] public int width;
        [MinValue(2)] public int height;

        [Header("Win Condition")]
        [HorizontalLine(color: EColor.Indigo)]
        [MinValue(0)]
        public int target;
    }
}
