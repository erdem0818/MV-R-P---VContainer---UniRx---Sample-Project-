using Assets.Mine.Scripts.LevelSystem;
using UnityEngine;
using VContainer.Unity;

namespace Assets.Mine.Scripts.Utils
{
    public class CameraSizeHandler : IStartable
    {
        private readonly LevelContainer _levelContainer;
        //todo save system

        public CameraSizeHandler(LevelContainer container)
        {
            _levelContainer = container;
        }

        public void Start()
        {
            int w = _levelContainer.GetLevel(0).width;
            int h = _levelContainer.GetLevel(0).height;

            const float wRatio = 1.25f;
            const float hRatio = 0.625f;

            float wSize = w * wRatio;
            float hSize = h * hRatio;

            Camera.main.orthographicSize = Mathf.Max(wSize, hSize);
        }
    }
}

