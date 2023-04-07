using UnityEngine;
using Assets.Scripts.Logic;
using Assets.Scripts.Logic.Enemies.EnemyStates;

public abstract class EnemyAttacking : MonoBehaviour, IAttack
{
    public EnemyDetecting EnemyDetecting;
    protected IEnemyStateMachine _stateMachine;

    private void Awake()
    {
        _stateMachine = transform.GetComponent<IEnemyStateMachine>();
    }

    private void OnEnable()
    {
        EnemyDetecting.OnDetectEvent += Attack;
        EnemyDetecting.OnDetectEvent += Attack;
    }

    private void OnDisable()
    {
        EnemyDetecting.OnDetectEvent -= Attack;
        EnemyDetecting.OnDetectEvent -= Attack;
    }

    public abstract void Attack();


}
