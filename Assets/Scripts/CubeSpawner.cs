using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner :  ElementsCounter
{
    [SerializeField] private CubePool _pool;
    [SerializeField] private float _timeout;
    [SerializeField] private Vector2 _positionMin;
    [SerializeField] private Vector2 _positionMax;
    
    private bool _isActive;
    private WaitForSeconds _spawnTimeout;

    public event Action<Vector3> CubeDestroyed;
    
    private void Awake()
    {
        _isActive = true;
        _spawnTimeout = new(_timeout);

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (_isActive)
        {

            Cube cube = _pool.Get();
            cube.Destroyed += PutCubeIntoPool;

            IncrementAllElementsCount();
            IncrementActiveElementsCount();
            
            Vector3 position = new (Random.Range(_positionMin.x, _positionMax.x), transform.position.y, Random.Range(_positionMin.y, _positionMax.y));
            
            cube.Init(position);

            yield return _spawnTimeout;
        }
    }

    private void PutCubeIntoPool(Cube cube)
    {
        cube.Destroyed -= PutCubeIntoPool;
        _pool.Put(cube);
        CubeDestroyed?.Invoke(cube.transform.position);
        DecrementActiveElementsCount();
    }
}
