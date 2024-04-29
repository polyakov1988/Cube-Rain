using System;
using UnityEngine;

public class CubeCollisionHandler : MonoBehaviour
{
    public event Action Fallen;

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.TryGetComponent(out Plane plane))
        {
            Fallen?.Invoke();
        }
    }
}
