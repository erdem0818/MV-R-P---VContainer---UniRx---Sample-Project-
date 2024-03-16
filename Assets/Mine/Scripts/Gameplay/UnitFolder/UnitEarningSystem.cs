using Mine.Scripts.Injection;
using Mine.Scripts.Utils;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Mine.Scripts.Gameplay.UnitFolder
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
                if (!(_counter <= 0)) return;
                
                _counter = interval;
                _scoreModel.score.Value += Context.Model.Score.Value;
            }).AddTo(Context.gameObject);

        }
    }
}