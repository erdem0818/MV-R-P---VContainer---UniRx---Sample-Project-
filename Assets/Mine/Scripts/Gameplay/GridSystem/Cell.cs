using Assets.Mine.Scripts.Gameplay.Unit;
using UnityEngine;

namespace Assets.Mine.Scripts.Gameplay.GridSystem
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
