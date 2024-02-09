using Assets.Mine.Scripts.Gameplay.UI;
using Assets.Mine.Scripts.Injection;
using Assets.Mine.Scripts.Utils;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Assets.Mine.Scripts.Gameplay.Unit
{
    public class UnitEarningSystem : VObject<UnitContext>, IStartable
    {
        [Inject] private readonly ScoreModel _scoreModel;
        private float _counter;

        public void Start()
        {
            const float interval = 2.5f;
            _counter = interval;

            //todo look interval in uniRX
            Observable.EveryUpdate().Subscribe(_ => 
            {
                _counter -= Time.deltaTime;
                if(_counter <= 0)
                {
                    _counter = interval;
                    //Debug.Log($"Earned Score: {Context.model.Score.Value}");
                    _scoreModel.Score.Value += Context.model.Score.Value;
                }
            }).AddTo(Context.gameObject);

        }
    }
}