using UnityEngine;
using TMPro;

/// <summary>
/// Manages the candy system and candy system functions.
/// </summary>
public class CandyManager : MonoBehaviour
{
    [Header("UI Objects")]
    [SerializeField] private TMP_Text candyCountText;

    [Header("Manager Properties")]
    [SerializeField] private int candyLimit;

    private int candy;

    /// <summary>
    /// Adds a given amount of candy to the candy total.
    /// Cannot be higher than the candy limit.
    /// </summary>
    /// <param name="val">The amount of candy to add.</param>
    public void AddCandy(int val)
    {
        candy = Mathf.Clamp(candy + val, 0, candyLimit);
        UpdateCandyText();
    }

    /// <summary>
    /// Subtracts a specified amount of candy from the candy total.
    /// Cannot be lower than zero.
    /// </summary>
    /// <param name="val">The amount of candy to subtract.</param>
    public void RemoveCandy(int val)
    {
        candy = Mathf.Clamp(candy - val, 0, candyLimit);
        UpdateCandyText();
    }

    /// <summary>
    /// Updates the candy text UI field to the current candy
    /// total.
    /// </summary>
    private void UpdateCandyText()
    {
        candyCountText.text = candy.ToString();
    }
}
