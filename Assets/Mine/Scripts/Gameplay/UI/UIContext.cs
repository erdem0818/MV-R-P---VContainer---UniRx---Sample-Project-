using Assets.Mine.Scripts.Gameplay.Unit;
using NaughtyAttributes;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Assets.Mine.Scripts.Gameplay.UI
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
            Instantiate(unitProviderContext, canvas.transform);
            Instantiate(scoreTextContext, canvas.transform);
        }
    }
}

