using Assets.Mine.Scripts.Gameplay.Factory;
using Assets.Mine.Scripts.Gameplay.GridSystem;
using Assets.Mine.Scripts.Utils;
using NaughtyAttributes;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

namespace Assets.Mine.Scripts.Injection
{
    public class ScoreModel
    {
        public ReactiveProperty<int> Score = new(0);
    }

    public class MainContext : LifetimeScope
    {
        [Header("Unit Parent")]
        [HorizontalLine(color: EColor.Yellow)]
        [SerializeField] private Transform parent;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<Gameplay.GridSystem.Grid>(Lifetime.Singleton);
            builder.RegisterEntryPoint<GridInitializer>(Lifetime.Singleton);
            builder.RegisterEntryPoint<CameraSizeHandler>(Lifetime.Singleton);
            builder.RegisterInstance<ScoreModel>(new ScoreModel());

            builder.RegisterInstance(parent);
            builder.Register<UnitFactory>(Lifetime.Singleton);
        }
    }

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
}