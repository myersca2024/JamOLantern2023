using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


/// <summary>
/// In charge of the timer of the game, which houses the player has visited in each costume, and informing an npc when it's costume has been stolen?
/// </summary>
public class GameManager : MonoBehaviour
{
    private Dictionary<Costume, List<Guid>> housesVisitedInCostume;
    private Costume currentCostume;

    // Start is called before the first frame update
    void Start()
    {
        housesVisitedInCostume = new Dictionary<Costume, List<Guid>>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CandyTaken(Guid houseId)
    {
        if (housesVisitedInCostume.ContainsKey(currentCostume))
        {
            housesVisitedInCostume[currentCostume].Add(houseId);
        }
        else
        {
            housesVisitedInCostume.Add(currentCostume, new List<Guid> { houseId });
        }
    }

    public bool CanTakeCandy(Guid houseId)
    {
        return !(housesVisitedInCostume.ContainsKey(currentCostume) && housesVisitedInCostume[currentCostume].Contains(houseId));
    }

    public void CostumeTaken(GameObject npc, Costume costumeTaken)
    {
        // put logic for making the npc sad because its costume got stolen
        currentCostume = costumeTaken;
        npc.GetComponentInChildren<NPCWalkAnimationController>().SetSadWalk(true);
    }
}
