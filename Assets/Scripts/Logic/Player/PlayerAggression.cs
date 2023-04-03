using Assets.Scripts.Logic;
using UnityEngine;

public class PlayerAggression : MonoBehaviour, IAggressable
{
    public AggressionArea AggressionArea;
    public PlayerMove PlayerMover;

    public GameObject CurrentAgressionOnbject { get; private set; }

    private void OnEnable()
    {
        AggressionArea.OnAggressionEnterEvent += Aggress;
        AggressionArea.OnAggressionExitEvent += UnAggress;
    }

    private void OnDisable()
    {
        AggressionArea.OnAggressionEnterEvent -= Aggress;
        AggressionArea.OnAggressionExitEvent -= UnAggress;
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
            Debug.Log("Слежу за объектом");
            CurrentAgressionOnbject = other.gameObject;
        }
    }

    public void UnAggress(Collider other)
    {
        if(other.gameObject == CurrentAgressionOnbject)
        {
            Debug.Log("Не слежу за объектом");
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
