using Assets.Mine.Scripts.Gameplay.GridSystem;
using TMPro;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Assets.Mine.Scripts.Gameplay.Unit
{
    public class UnitContext : LifetimeScope
    {
        [System.Serializable]
        public class UnitModel
        {
            public ReactiveProperty<int> Score = new();
        }

        [System.Serializable]
        public class UnitView
        {
            public TextMeshPro textMesh;
        }

        public Cell LocatedCell { get; set; } = null;
        public bool isByMerge {get; set;} = false;
        [field: SerializeField] public UnitView view {get; private set; }
        [field: SerializeField] public UnitModel model{get; private set; }

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<UnitDragPresenter>();
            builder.RegisterEntryPoint<UnitEarningSystem>();

            model.Score.SubscribeWithState<int, TextMeshPro>(view.textMesh, (sc, tx) => tx.text = $"{sc}")
                .AddTo(gameObject);
        }

        public void UpdateScore(int score) => model.Score.Value = score;
    }
}
