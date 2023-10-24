using UnityEngine;

/// <summary>
/// Simple player controller using new Unity Input System.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float movementSpeed;

    [Header("Player Object Settings")]
    [SerializeField] private float playerHeight;
    [SerializeField] private float collisionDistance;

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
        Vector2 inputVector = PlayerInput.instance.GetPlayerMovementInput();
        Vector3 movementVector = new Vector3(inputVector.x, 0f, inputVector.y);
        if (!AttemptApplyMovement(movementVector))
        {
            if (!AttemptApplyMovement(new Vector3(movementVector.x, 0f, 0f)))
            {
                AttemptApplyMovement(new Vector3(0f, 0f, movementVector.z));
            }
        }
    }

    /// <summary>
    /// Attempts to move the player in the given direction. Fails if the player is not
    /// able to move in that direction.
    /// </summary>
    /// <param name="direction">The direction that the playeer is moving.</param>
    /// <returns>Whether or not the player successfully moved.</returns>
    private bool AttemptApplyMovement(Vector3 direction)
    {
        if (CanMove(direction))
        {
            transform.position += direction * movementSpeed * Time.deltaTime;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Detects if the player can keep moving in a given direction without colliding with
    /// another object.
    /// </summary>
    /// <param name="direction">The direction that the playeer is moving.</param>
    /// <returns>Whether or not the player can move in the given direction.</returns>
    private bool CanMove(Vector3 direction)
    {
        return !Physics.CapsuleCast(transform.position, 
                                    transform.position + Vector3.up * playerHeight, 
                                    collisionDistance, 
                                    direction, 
                                    movementSpeed * Time.deltaTime);
    }
}
