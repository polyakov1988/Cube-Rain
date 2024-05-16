using System;
using UnityEngine;

public abstract class ElementsCounter : MonoBehaviour
{
    private int _allElementsCount;
    private int _activeElementsCount;
    
    public event Action<int> AllElementsCountUpdated;
    public event Action<int> ActiveElementsCountUpdated;

    private void Awake()
    {
        _allElementsCount = 0;
        _activeElementsCount = 0;
        AllElementsCountUpdated?.Invoke(_allElementsCount);
        ActiveElementsCountUpdated?.Invoke(_activeElementsCount);
    }

    protected void IncrementAllElementsCount()
    {
        _allElementsCount++;
        AllElementsCountUpdated?.Invoke(_allElementsCount);
    }
    
    protected void IncrementActiveElementsCount()
    {
        _activeElementsCount++;
        ActiveElementsCountUpdated?.Invoke(_activeElementsCount);
    }
    
    protected void DecrementActiveElementsCount()
    {
        _activeElementsCount--;
        ActiveElementsCountUpdated?.Invoke(_activeElementsCount);
    }
}