using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

namespace Assets.Mine.Scripts.Gameplay.Unit
{
    public class UnitProviderContext : LifetimeScope
    {
        [System.Serializable]
        public class UnitProviderView
        {
            public Button button;
            public TextMeshProUGUI text;
        }

        [System.Serializable]
        public class UnitProviderModel
        {
            public ReactiveProperty<float> countDown = new();
        }

        [SerializeField] private UnitProviderView view;
        [SerializeField] private UnitProviderModel model;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(view);
            builder.RegisterInstance(model);
            builder.RegisterEntryPoint<UnitProviderPresenter>();
        }
    }
}

