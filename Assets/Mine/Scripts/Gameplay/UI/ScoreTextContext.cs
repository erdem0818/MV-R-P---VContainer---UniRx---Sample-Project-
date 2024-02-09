using Assets.Mine.Scripts.Injection;
using Assets.Mine.Scripts.Utils;
using TMPro;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using static Assets.Mine.Scripts.Gameplay.UI.ScoreTextContext;

namespace Assets.Mine.Scripts.Gameplay.UI
{
    public class ScoreTextContext : LifetimeScope 
    {
        [System.Serializable]
        public class ScoreView
        {
            public TextMeshProUGUI scoreText;
        }        

        [field: SerializeField] public ScoreView View {get; private set;}

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(View);
            builder.RegisterEntryPoint<ScoreUIPresenter>(Lifetime.Singleton);
        }
    }

    public class ScoreUIPresenter : VObject<ScoreTextContext>, IStartable
    {
        [Inject] private ScoreModel Model;
        [Inject] private ScoreView View;

        public void Start()
        {
            Model.Score.SubscribeWithState<int, TextMeshProUGUI>(View.scoreText, (sc, tx) => tx.text = $"{sc}")
                .AddTo(Context.gameObject);
        }
    }
}
