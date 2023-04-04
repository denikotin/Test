using System;
using UnityEngine;

public class AggressionArea : MonoBehaviour
{
    public event Action<Collider> OnAggressionAreaEnterEvent;
    public event Action<Collider> OnAggressionAreaExitEvent;

    private void OnTriggerEnter(Collider other)
    {
        OnAggressionAreaEnterEvent?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        OnAggressionAreaExitEvent?.Invoke(other);
    }
}
