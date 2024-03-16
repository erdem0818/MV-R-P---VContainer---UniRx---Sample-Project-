using Mine.Scripts.Injection;
using Mine.Scripts.Utils;
using TMPro;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using static Mine.Scripts.Gameplay.UI.ScoreTextContext;

namespace Mine.Scripts.Gameplay.UI
{
    public class ScoreTextContext : LifetimeScope 
    {
        [System.Serializable]
        public class ScoreView
        {
            public TextMeshProUGUI scoreText;
        }        

        [field: SerializeField] private ScoreView View {get; set;}

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(View);
            builder.RegisterEntryPoint<ScoreUIPresenter>();
        }
    }

    public class ScoreUIPresenter : VObject<ScoreTextContext>, IStartable
    {
        [Inject] private ScoreModel _model;
        [Inject] private ScoreView _view;

        public void Start()
        {
            _model.score.SubscribeWithState<int, TextMeshProUGUI>(_view.scoreText, (sc, tx) => tx.text = $"{sc}")
                .AddTo(Context.gameObject);
        }
    }
}
