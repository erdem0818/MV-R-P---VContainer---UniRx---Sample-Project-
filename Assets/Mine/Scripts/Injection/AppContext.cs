using Mine.Scripts.Gameplay.GridSystem;
using Mine.Scripts.Gameplay.UnitFolder;
using Mine.Scripts.Level_System;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Mine.Scripts.Injection
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

