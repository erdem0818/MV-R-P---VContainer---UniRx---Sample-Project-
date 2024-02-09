using Assets.Mine.Scripts.Gameplay.Unit;
using UnityEngine;
using VContainer.Unity;

namespace Assets.Mine.Scripts.Gameplay.Factory
{
    public class UnitFactory
    {
        private readonly UnitContext _prefab;
        private readonly Transform _parent;

        public UnitFactory(UnitContext prefab, Transform parent)
        {
            _prefab = prefab;
            _parent = parent;
        }

        public UnitContext Create(bool isByMerge = false)
        {
            var unit = VContainerSettings.Instance.RootLifetimeScope.Container.Instantiate(_prefab, _parent);
            unit.isByMerge = isByMerge;
            return unit;
        }

        public UnitContext CreateByMerge(UnitContext first, UnitContext second)
        {
            int score = first.model.Score.Value * 2;

            Object.Destroy(first.gameObject);
            Object.Destroy(second.gameObject);

            var unit = Create(true);
            unit.transform.parent = _parent;
            unit.UpdateScore(score);

            return unit;
        }
    }
}

