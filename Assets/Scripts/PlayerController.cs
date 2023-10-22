using UnityEngine;

/// <summary>
/// Simple player controller using new Unity Input System.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float movementSpeed;

    private PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();

        playerControls.Player.Enable();
    }

    private void Update()
    {
        MovePlayer();
    }

    /// <summary>
    /// Moves player by reading the "Movement" Vector2 in PlayerControls.
    /// Called every frame.
    /// </summary>
    private void MovePlayer()
    {
        Vector2 inputVector = playerControls.Player.Movement.ReadValue<Vector2>();
        Vector3 movementVector = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += movementVector * movementSpeed * Time.deltaTime;
    }
}
