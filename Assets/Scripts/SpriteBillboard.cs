using UnityEngine;

/// <summary>
/// Script behavior for making sprites face the camera.
/// </summary>
public class SpriteBillboard : MonoBehaviour
{
    private Transform cameraTransform;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        RotateObject();
    }

    /// <summary>
    /// Makes transform of object face the main camera.
    /// </summary>
    private void RotateObject()
    {
        transform.LookAt(cameraTransform);
    }
}
