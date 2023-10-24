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
        RotateObject();
    }

    /// <summary>
    /// Makes transform of object face the main camera.
    /// </summary>
    private void RotateObject()
    {
        float cameraFacingAngle = 180f - Vector3.Angle(cameraTransform.position + Vector3.up, cameraTransform.forward);
        transform.eulerAngles = new Vector3(cameraFacingAngle, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
