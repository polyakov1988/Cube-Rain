using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private ElementsInfoView _elementsInfoView;
    [SerializeField] private ElementsCounter _cubeCounter;
    [SerializeField] private ElementsCounter _bombCounter;

    private void Awake()
    {
        ElementsInfoMediator mediator = new (_elementsInfoView, _cubeCounter, _bombCounter);
    }
}