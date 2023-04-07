using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.CoroutineServiceFolder
{
    public class CoroutineService
    {
        private ICoroutineRunner _coroutineRunner;
        private Coroutine _currentCoroutine;

        public CoroutineService(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void StartCoroutine(IEnumerator coroutine)
        {
            _currentCoroutine = _coroutineRunner.StartCoroutine(coroutine);
        }
    }
}
