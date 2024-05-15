using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private CubeCollisionHandler _collisionHandler;
    [SerializeField] private Renderer _cubeRenderer;
    [SerializeField] private Color _defaultColor;

    private bool _isChanged;

    public void Init()
    {
        _cubeRenderer.material.color = _defaultColor;
        _isChanged = false;
    }

    private void OnEnable()
    {
        _collisionHandler.Fallen += ChangeColor;
    }

    private void OnDisable()
    {
        _collisionHandler.Fallen -= ChangeColor;
    }

    private void ChangeColor()
    {
        if (_isChanged)
            return;
        
        _cubeRenderer.material.color = Random.ColorHSV();
        _isChanged = true;
    }
}

