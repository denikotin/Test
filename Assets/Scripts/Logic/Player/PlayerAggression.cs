using Assets.Scripts.Logic;
using UnityEngine;

public class PlayerAggression : MonoBehaviour, IAggressable
{
    public AggressionArea AggressionArea;
    public PlayerMove PlayerMover;

    public GameObject CurrentAgressionOnbject { get; private set; }

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

    private void Update()
    {
        if(!PlayerMover.IsMoving)
        {
            Monitor();     
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

    private void Monitor()
    {
        if(CurrentAgressionOnbject != null)
        {
            transform.LookAt(CurrentAgressionOnbject.transform);
        }
    }
}
