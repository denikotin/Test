using Assets.Scripts.Logic;
using UnityEngine;

public class PlayerAggression : MonoBehaviour, IAggressable
{
    public AggressionArea AggressionArea;
    public PlayerMover PlayerMover;

    private GameObject _currentAgressionOnbject;

    private void OnEnable()
    {
        AggressionArea.OnAggressionExitEvent += Aggress;
        AggressionArea.OnAggressionExitEvent += UnAggress;
    }

    private void OnDisable()
    {
        AggressionArea.OnAggressionExitEvent -= Aggress;
        AggressionArea.OnAggressionExitEvent -= UnAggress;
    }

    private void Update()
    {
        if((_currentAgressionOnbject != null) && (!PlayerMover.IsMoving))
        {
            Monitor();     
        }
    }

    public void Aggress(Collider other)
    {
        Debug.Log(other.name);
        if(other.CompareTag("Enemy"))
        {
            _currentAgressionOnbject = other.gameObject;
        }
    }

    public void UnAggress(Collider other)
    {
        if(other == _currentAgressionOnbject)
        {
            _currentAgressionOnbject = null;
        }
    }

    private void Monitor()
    {
        transform.LookAt(_currentAgressionOnbject.transform);
    }
}
