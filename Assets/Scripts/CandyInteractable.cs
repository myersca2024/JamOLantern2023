using UnityEngine;

/// <summary>
/// An InteractableObject that gives the player a set amount of candy.
/// </summary>
public class CandyInteractable : InteractableObject
{
    [Header("Candy Interactable Settings")]
    [SerializeField] private int candyToGive;

    private CandyManager candyManager;

    private void Awake()
    {
        candyManager = FindObjectOfType<CandyManager>();
    }

    public override void Execute()
    {
        candyManager.AddCandy(candyToGive);
    }
}
