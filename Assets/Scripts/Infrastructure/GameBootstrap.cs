using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public class GameBootstrap : MonoBehaviour, ICoroutineRunner
    {
        public GameObject LoadCurtain;
        private Game _game;

        private void Awake()
        {
            _game = new Game(this,Instantiate(LoadCurtain));
            _game.Run();

            DontDestroyOnLoad(gameObject);
        }
    }
}
