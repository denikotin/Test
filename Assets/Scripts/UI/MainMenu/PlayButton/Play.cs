using Assets.Scripts.Infrastructure.StateMachine;
using Assets.Scripts.Infrastructure.StateMachine.States;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    public Button PlayButton;
    private IGameStateMachine _gameStateMachine;


    public void Construct(IGameStateMachine gameStateMachine) => _gameStateMachine = gameStateMachine;

    private void Start() => PlayButton.onClick.AddListener(PlayGame);

    private void PlayGame() => _gameStateMachine.EnterToState<LoadPlaySceneState, string>("Play");
}
