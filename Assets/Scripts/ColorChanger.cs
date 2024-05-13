using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private CubeCollisionHandler _collisionHandler;
    [SerializeField] private Renderer _cubeRenderer;

    private bool _isChanged;

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

