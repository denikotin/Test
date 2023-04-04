using Assets.Scripts.Logic;
using Assets.Scripts.Logic.Enemies.EnemyStates;
using UnityEngine;

public abstract class EnemyAggression : MonoBehaviour, IAggressable
{
    public AggressionArea AggressionArea;
    protected IEnemyStateMachine _stateMachine;

    private void Awake()
    {
        _stateMachine = transform.GetComponent<IEnemyStateMachine>();
    }

    private void OnEnable()
    {
        AggressionArea.OnAggressionAreaEnterEvent += Aggress;
        AggressionArea.OnAggressionAreaExitEvent += UnAggress;
    }

    private void OnDisable()
    {
        AggressionArea.OnAggressionAreaEnterEvent -= Aggress;
        AggressionArea.OnAggressionAreaExitEvent -= UnAggress;
    }

    public abstract void Aggress(Collider other);


    public abstract void UnAggress(Collider other);

}
