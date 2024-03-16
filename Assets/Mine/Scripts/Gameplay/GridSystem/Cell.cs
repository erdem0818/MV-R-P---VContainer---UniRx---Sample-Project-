using Mine.Scripts.Gameplay.UnitFolder;
using UnityEngine;

namespace Mine.Scripts.Gameplay.GridSystem
{
    public class Cell : MonoBehaviour
    {
        public bool IsEmpty {get; set;} = true;

        private UnitContext _unit;
        public UnitContext PlacedUnit 
        {
            get => _unit;
            set
            {
                _unit = value;
                IsEmpty = _unit == null;
            }
        } 
    }
}
