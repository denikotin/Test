using UnityEngine;
using Assets.Scripts.Logic;
using Assets.Scripts.Logic.Enemies.EnemyStates;

public abstract class EnemyAttacking : MonoBehaviour, IAttackable
{
    public AttackingArea AttackingArea;
    protected IEnemyStateMachine _stateMachine;

    private void Awake()
    {
        _stateMachine = transform.GetComponent<IEnemyStateMachine>();
    }

    private void OnEnable()
    {
        AttackingArea.OnAttackingAreaEnterEvent += OnAttackAreaEnter;
        AttackingArea.OnAttackingAreaExitEvent += OnAttaclAreaExit;
    }

    private void OnDisable()
    {
        AttackingArea.OnAttackingAreaEnterEvent -= OnAttackAreaEnter;
        AttackingArea.OnAttackingAreaExitEvent-= OnAttaclAreaExit;
    }

    public abstract void OnAttackAreaEnter(Collider other);

    public abstract void OnAttaclAreaExit(Collider other);

}
