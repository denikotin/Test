using Assets.Scripts.Logic.Enemies;
using System;
using UnityEngine;


public abstract class EnemyDetecting : MonoBehaviour, IDetectable
{
    public float DetectRadius;

    public event Action OnDetectEvent;
    protected Transform _target;

    public void Construct(Transform player) => _target = player;

    public void Update()
    {
        float distancce = Vector3.Distance(_target.position, transform.position);
        if(distancce <= DetectRadius)
        {
            Detect();
        }
    }

    public void Detect() => OnDetectEvent?.Invoke();


    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, DetectRadius);
    }
}
