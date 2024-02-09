using System.Collections.Generic;
using UnityEngine;

namespace Assets.Mine.Scripts.LevelSystem
{
    [CreateAssetMenu(menuName = "Data/Level Container", fileName = "Level Container")]
    public class LevelContainer : ScriptableObject
    {
        [SerializeField] private List<Level> Levels;

        public Level GetLevel(int index)
        {
            if(index < 0) return Levels[0];
            if(index >= Levels.Count) return Levels[Levels.Count - 1];
            return Levels[index];
        }
    }
}
