using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostumeInteractable : InteractableObject
{
    private CostumeManager costumeManager;
    private GameManager gameManager;
    [SerializeField] private string costume;

    private void Awake()
    {
        costumeManager = FindObjectOfType<CostumeManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void SetCostume(string newCostume)
    {
        costume = newCostume;
        // possible location for changing sprite based on given costume
    }

    public override void Execute()
    {
        if (costume != null)
        {
            costumeManager.StealCostume(costume);
            gameManager.CostumeTaken(gameObject);
            SetCostume(null);
        }
    }
}
