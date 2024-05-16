using TMPro;
using UnityEngine;

public class ElementsInfoView : MonoBehaviour
{
    [SerializeField] private TMP_Text _allCubes;
    [SerializeField] private TMP_Text _activeCubes;
    [SerializeField] private TMP_Text _allBombs;
    [SerializeField] private TMP_Text _activeBombs;

    public void UpdateAllCubesView(int count)
    {
        _allCubes.text = count.ToString();
    }
    
    public void UpdateActiveCubesView(int count)
    {
        _activeCubes.text = count.ToString();
    }
    
    public void UpdateAllBombsView(int count)
    {
        _allBombs.text = count.ToString();
    }
    
    public void UpdateActiveBombsView(int count)
    {
        _activeBombs.text = count.ToString();
    }
}