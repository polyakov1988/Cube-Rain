using UnityEngine;

public class BombSpawner : ElementsCounter
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private BombPool _bombPool;

    private void OnEnable()
    {
        _cubeSpawner.CubeDestroyed += Spawn;
    }

    private void OnDisable()
    {
        _cubeSpawner.CubeDestroyed -= Spawn;
    }

    private void Spawn(Vector3 position)
    {
        Bomb bomb = _bombPool.Get();
        bomb.Exploded += PutIntoPool;
        
        IncrementAllElementsCount();
        IncrementActiveElementsCount();
        
        bomb.Init(position);
    }

    private void PutIntoPool(Bomb bomb)
    {
        bomb.Exploded -= PutIntoPool;
        _bombPool.Put(bomb);
        DecrementActiveElementsCount();
    }
}