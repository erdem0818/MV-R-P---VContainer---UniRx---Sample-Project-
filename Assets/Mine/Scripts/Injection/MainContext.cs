using Mine.Scripts.Gameplay.FactoryFolder;
using Mine.Scripts.Gameplay.GridSystem;
using Mine.Scripts.Utils;
using NaughtyAttributes;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Grid = Mine.Scripts.Gameplay.GridSystem.Grid;

namespace Mine.Scripts.Injection
{
    public class ScoreModel
    {
        public readonly ReactiveProperty<int> score = new(0);
    }

    public class MainContext : LifetimeScope
    {
        [Header("Unit Parent")]
        [HorizontalLine(color: EColor.Yellow)]
        [SerializeField] private Transform parent;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<Grid>(Lifetime.Singleton);
            builder.RegisterEntryPoint<GridInitializer>();
            builder.RegisterEntryPoint<CameraSizeHandler>();
            builder.RegisterInstance<ScoreModel>(new ScoreModel());

            builder.RegisterInstance(parent);
            builder.Register<UnitFactory>(Lifetime.Singleton);
        }
    }
/*
    #region Sample
    public class SampleView
    {
        public Button button;
        public TextMeshProUGUI text;
    }

    // The Model. All property notify when their values change
    public class SampleModel
    {
        public ReactiveProperty<int> Coin {get; private set;}

        public SampleModel()
        {
            Coin = new ReactiveProperty<int>(10);
        }
    }

    public class SamplePresenter
    {
        private SampleView _view;
        private SampleModel _model;

        public void Init()
        {
            // Rx supplies user events from Views and Models in a reactive manner 
            _view.button.OnClickAsObservable().Subscribe(onNext: _ => _model.Coin.Value -= 1);
            // Models notify Presenters via Rx, and Presenters update their views
            _model.Coin.SubscribeWithState<int, TextMeshProUGUI>(_view.text, (c, tx) => tx.text = $"{c}");
        }
    }
    #endregion
    */
}