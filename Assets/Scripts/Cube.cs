using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    [SerializeField] private CubeCollisionHandler _collisionHandler;
    [SerializeField] private int _lifeTimeMin;
    [SerializeField] private int _lifeTimeMax;
    
    private WaitForSeconds _lifeTime;
    
    public event Action<Cube> Destroyed;

    private void OnEnable()
    {
        _collisionHandler.Fallen += OnFallen;
    }

    private void OnDisable()
    {
        _collisionHandler.Fallen -= OnFallen;
    }

    public void Init(Vector3 position)
    {
        transform.position = position;
        _lifeTime = new (Random.Range(_lifeTimeMin, _lifeTimeMax));
    }

    private void OnFallen()
    {
        StartCoroutine(StartTimer());
        
    }
    
    private IEnumerator StartTimer()
    {
        yield return _lifeTime;
        
        Destroyed?.Invoke(this);
    }
}
