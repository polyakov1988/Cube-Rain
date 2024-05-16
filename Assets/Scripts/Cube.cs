using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    [SerializeField] private CubeCollisionHandler _collisionHandler;
    [SerializeField] private int _lifeTimeMin;
    [SerializeField] private int _lifeTimeMax;
    [SerializeField] private ColorChanger _colorChanger;
    
    private WaitForSeconds _lifeTime;
    
    public event Action<Cube> Destroyed;

    private void OnEnable()
    {
        _collisionHandler.Fallen += OnFallen;
    }

    public void Init(Vector3 position)
    {
        _colorChanger.Init();
        transform.position = position;
        _lifeTime = new (Random.Range(_lifeTimeMin, _lifeTimeMax));
    }

    private void OnFallen()
    {
        _collisionHandler.Fallen -= OnFallen;
        StartCoroutine(DestroyAfterLifeTime());
    }
    
    private IEnumerator DestroyAfterLifeTime()
    {
        yield return _lifeTime;
        
        Destroyed?.Invoke(this);
    }
}
