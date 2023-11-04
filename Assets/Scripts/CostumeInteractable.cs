using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Costume
{
    NoCostume,
    Ghost,
    Frankenstein
}

public class CostumeInteractable : InteractableObject
{
    private CostumeManager costumeManager;
    private GameManager gameManager;
    private Animator costumeAnimator;
    private Costume costume;

    private void Awake()
    {
        costumeManager = FindObjectOfType<CostumeManager>();
        gameManager = FindObjectOfType<GameManager>();
        costumeAnimator = GetComponent<Animator>();
        SelectRandomCostume();
    }

    private void SelectRandomCostume()
    {
        int randIndex = Random.Range(1, System.Enum.GetNames(typeof(Costume)).Length); // Start from 1 because 0 is no costume
        SetCostume((Costume)randIndex);
    }

    public void SetCostume(Costume newCostume)
    {
        costume = newCostume;
        costumeAnimator.SetInteger("CostumeIndex", (int)costume);
    }

    public override void Execute()
    {
        Debug.Log("COSTUME EXECUTE CALLED");
        if (costume != Costume.NoCostume)
        {
            costumeManager.StealCostume(costume);
            gameManager.CostumeTaken(transform.parent.gameObject, costume);
            SetCostume(Costume.NoCostume);
        }
    }
}
