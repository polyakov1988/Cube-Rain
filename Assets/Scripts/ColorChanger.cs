using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private CubeCollisionHandler _collisionHandler;
    [SerializeField] private Renderer _cubeRenderer;

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
        _cubeRenderer.material.color = Random.ColorHSV();
    }
}

