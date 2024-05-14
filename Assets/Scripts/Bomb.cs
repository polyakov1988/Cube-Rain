using System;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;

public class Bomb : MonoBehaviour
{
    [SerializeField] private int _lifeTimeMin;
    [SerializeField] private int _lifeTimeMax;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private float _radius;
    [SerializeField] private float _force;

    private const float DefaultAlpha = 1;
    private float _timer;
    public event Action<Bomb> Exploded; 
    
    public void Init(Vector3 position)
    {
        SetDefaultAlpha();
        transform.position = position;
        _timer = Random.Range(_lifeTimeMin, _lifeTimeMax);
        _renderer.material.DOFade(0, _timer).OnComplete(Explode);
    }

    private void SetDefaultAlpha()
    {
        Material material = _renderer.material;
        Color color = material.color;
        color.a = DefaultAlpha;
        material.color = color;
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);
        
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(_force, transform.position, _radius);
        }
        
        Exploded?.Invoke(this);
    }
}