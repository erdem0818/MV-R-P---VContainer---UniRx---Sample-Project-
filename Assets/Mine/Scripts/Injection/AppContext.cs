using Assets.Mine.Scripts.Gameplay.GridSystem;
using Assets.Mine.Scripts.Gameplay.Unit;
using Assets.Mine.Scripts.LevelSystem;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Assets.Mine.Scripts.Injection
{
    public class AppContext : LifetimeScope
    {
        [SerializeField] private LevelContainer levelContainer;
        [SerializeField] private Cell cellPrefab;
        [SerializeField] private UnitContext unitContext;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(levelContainer);
            builder.RegisterInstance(cellPrefab);
            builder.RegisterInstance(unitContext);
        }
    }
}

