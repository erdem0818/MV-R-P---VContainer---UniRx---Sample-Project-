using Mine.Scripts.Gameplay.UnitFolder;
using NaughtyAttributes;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Mine.Scripts.Gameplay.UI
{
    public class UIContext : LifetimeScope
    {
        [Header("Canvas")]
        [SerializeField] private Canvas canvas;

        [Header("UI Prefabs")]
        [HorizontalLine(color: EColor.Pink)]

        [SerializeField] private UnitProviderContext unitProviderContext;
        [SerializeField] private ScoreTextContext scoreTextContext;

        protected override void Configure(IContainerBuilder builder)
        {
            //VContainerSettings.Instance.RootLifetimeScope.Container.Instantiate(unitProviderContext, canvas.transform);
            //VContainerSettings.Instance.RootLifetimeScope.Container.Instantiate(scoreTextContext, canvas.transform);

            Instantiate(unitProviderContext, canvas.transform);
            Instantiate(scoreTextContext, canvas.transform);
        }
    }
}

