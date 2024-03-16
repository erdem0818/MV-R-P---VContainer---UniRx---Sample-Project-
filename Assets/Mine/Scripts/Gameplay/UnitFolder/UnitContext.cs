using Mine.Scripts.Gameplay.GridSystem;
using TMPro;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Mine.Scripts.Gameplay.UnitFolder
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
        public bool IsByMerge {get; set;} = false;
        [field: SerializeField] public UnitView View {get; private set; }
        [field: SerializeField] public UnitModel Model{get; private set; }

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<UnitDragPresenter>();
            builder.RegisterEntryPoint<UnitEarningSystem>();

            Model.Score.SubscribeWithState<int, TextMeshPro>(View.textMesh, (sc, tx) => tx.text = $"{sc}")
                .AddTo(gameObject);
        }

        public void UpdateScore(int score) => Model.Score.Value = score;
    }
}
