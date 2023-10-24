using UnityEngine;

/// <summary>
/// A singleton class container for an instance of the PlayerControls input class.
/// Other classes are meant to retrieve this to track player input.
/// </summary>
public class PlayerInput : MonoBehaviour
{
    // Singleton instance
    public static PlayerInput instance;

    private PlayerControls playerControls;

    private void Awake()
    {
        instance = this;
        playerControls = new PlayerControls();

        playerControls.Player.Enable();
    }

    /// <summary>
    /// Reads the player movement vector.
    /// </summary>
    /// <returns>The player movement vector.</returns>
    public Vector2 GetPlayerMovementInput()
    {
        return playerControls.Player.Movement.ReadValue<Vector2>();
    }

    /// <summary>
    /// Reads the player's interact button.
    /// </summary>
    /// <returns>The status of the interact button being pressed.</returns>
    public bool GetInteractPressed()
    {
        return playerControls.Player.Interact.WasPressedThisFrame();
    }
}
