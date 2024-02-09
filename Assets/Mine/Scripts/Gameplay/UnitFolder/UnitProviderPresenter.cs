using Assets.Mine.Scripts.Gameplay.Factory;
using Assets.Mine.Scripts.Gameplay.GridSystem;
using Assets.Mine.Scripts.Utils;
using TMPro;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Assets.Mine.Scripts.Gameplay.Unit
{
    public class UnitProviderPresenter : VObject<UnitProviderContext>, IStartable
    {
        [Inject] private readonly GridSystem.Grid _grid;

        private readonly UnitFactory _unitFactory;
        private readonly UnitProviderContext.UnitProviderView _view;
        private readonly UnitProviderContext.UnitProviderModel _model;

        public UnitProviderPresenter(UnitFactory factory,
                                    UnitProviderContext.UnitProviderView view,
                                    UnitProviderContext.UnitProviderModel model)
        {
            _unitFactory = factory;
            _view = view;
            _model = model;
        }

        public void Start()
        {
            InitalizeView();
        }

        private void InitalizeView()
        {
            Observable.EveryUpdate().Subscribe(_ =>
            {
                if(_grid.IsFull() == false)
                    _model.countDown.Value -= Time.deltaTime;
                    
                if(_model.countDown.Value <= 0)
                {
                    UnitContext unit = _unitFactory.Create(false);
                    _model.countDown.Value = 10f;
                }
            }).AddTo(Context.gameObject);

            _model.countDown.SubscribeWithState<float, TextMeshProUGUI>(_view.text, (cd, tx) => tx.text = $"{Mathf.CeilToInt(cd)}");

            _view.button.OnClickAsObservable().Subscribe(_ => 
            {
                if(_grid.IsFull()) return;

                if(_model.countDown.Value > 0)
                {
                    _model.countDown.Value -= 1.0f;
                    _model.countDown.Value = Mathf.Clamp(_model.countDown.Value, 0f, 10f);
                }
            }).AddTo(Context.gameObject);

        }
    }
}
