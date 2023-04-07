using Assets.Scripts.Logic;
using Assets.Scripts.Logic.Player;
using UnityEngine;

public class PlayerAttacking : MonoBehaviour, IAttack
{
    public PlayerMove PlayerMover;
    public PlayerShoot PlayerShoot;
    public AttackingArea AttackingArea;
    public PlayerWeapon 

    public GameObject CurrentAgressionOnbject { get; private set; }

    private void OnEnable()
    {
        AttackingArea.OnAttackingAreaEnterEvent += Aggress;
        AttackingArea.OnAttackingAreaExitEvent += UnAggress;
    }

    private void OnDisable()
    {
        AttackingArea.OnAttackingAreaEnterEvent -= Aggress;
        AttackingArea.OnAttackingAreaExitEvent -= UnAggress;
    }

    private void Update()
    {
        if(!PlayerMover.IsMoving)
        {
            Attack();
        }
    }
    public void Attack()
    {
        if (CurrentAgressionOnbject != null)
        {
            transform.LookAt(CurrentAgressionOnbject.transform);
            PlayerShoot.Shoot();
        }
    }

    public void Aggress(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            CurrentAgressionOnbject = other.gameObject;
        }
    }

    public void UnAggress(Collider other)
    {
        if(other.gameObject == CurrentAgressionOnbject)
        {
            CurrentAgressionOnbject = null;
        }

    }
}
