using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostumeManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StealCostume(string newCostume)
    {
        Debug.Log($"{newCostume} was stolen!");
        // logic to change sprite of player character based on stolen costume
    }
}
