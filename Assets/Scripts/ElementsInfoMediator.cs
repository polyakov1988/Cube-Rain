using System;
using UnityEngine;

public class ElementsInfoMediator : IDisposable
{
    private readonly ElementsInfoView _elementsInfoView;
    private readonly ElementsCounter _cubeCounter;
    private readonly ElementsCounter _bombCounter;

    public ElementsInfoMediator(ElementsInfoView elementsInfoView, ElementsCounter cubeCounter, ElementsCounter bombCounter)
    {
        _elementsInfoView = elementsInfoView;
        _cubeCounter = cubeCounter;
        _bombCounter = bombCounter;

        Subscribe();
    }

    private void Subscribe()
    {
        _cubeCounter.AllElementsCountUpdated += OnAllCubesCountUpdated;
        _cubeCounter.ActiveElementsCountUpdated += OnActiveCubesCountUpdated;
        _bombCounter.AllElementsCountUpdated += OnAllBombsCountUpdated;
        _bombCounter.ActiveElementsCountUpdated += OnActiveBombsCountUpdated;
    }

    private void OnAllCubesCountUpdated(int count)
    {
        _elementsInfoView.UpdateAllCubesView(count);
    }
    
    private void OnActiveCubesCountUpdated(int count)
    {
        _elementsInfoView.UpdateActiveCubesView(count);
    }
    
    private void OnAllBombsCountUpdated(int count)
    {
        _elementsInfoView.UpdateAllBombsView(count);
    }
    
    private void OnActiveBombsCountUpdated(int count)
    {
        _elementsInfoView.UpdateActiveBombsView(count);
    }

    public void Dispose()
    {
        _cubeCounter.AllElementsCountUpdated -= OnAllCubesCountUpdated;
        _cubeCounter.ActiveElementsCountUpdated -= OnActiveCubesCountUpdated;
        _bombCounter.AllElementsCountUpdated -= OnAllBombsCountUpdated;
        _bombCounter.ActiveElementsCountUpdated -= OnActiveBombsCountUpdated;
    }
}