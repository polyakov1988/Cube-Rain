using System.Collections.Generic;
using UnityEngine;

public abstract class BasePool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    
    private readonly Queue<T> _queue = new ();

    public T Get()
    {
        if (_queue.Count == 0)
        {
            return Instantiate(_prefab);
        }

        T entity = _queue.Dequeue();
        entity.gameObject.SetActive(true);
        
        return entity;
    }

    public void Put(T entity)
    {
        entity.gameObject.SetActive(false);
        _queue.Enqueue(entity);
    }
}