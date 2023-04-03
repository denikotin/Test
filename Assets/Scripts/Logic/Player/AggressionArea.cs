using System;

using UnityEngine;

public class AggressionArea : MonoBehaviour
{
    public event Action<Collider> OnAggressionEnterEvent;
    public event Action<Collider> OnAggressionExitEvent;
        
    private void OnTriggerEnter(Collider other)
    {
        OnAggressionEnterEvent?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
       OnAggressionExitEvent?.Invoke(other);
    }
}
