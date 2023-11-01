using UnityEngine;
using System;

/// <summary>
/// An InteractableObject that gives the player a set amount of candy.
/// </summary>
public class CandyInteractable : InteractableObject
{
    [Header("Candy Interactable Settings")]
    [SerializeField] private int candyToGive;

    private CandyManager candyManager;
    private GameManager gameManager;
    private Guid houseId;

    private void Awake()
    {
        candyManager = FindObjectOfType<CandyManager>();
        gameManager = FindObjectOfType<GameManager>();
        houseId = Guid.NewGuid();
    }

    public override void Execute()
    {
        if (gameManager.CanTakeCandy(houseId))
        {
            candyManager.AddCandy(candyToGive);
            gameManager.CandyTaken(houseId);
        }
    }
}
