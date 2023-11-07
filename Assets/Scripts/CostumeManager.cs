using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostumeManager : MonoBehaviour
{
    private Animator costumeAnimator;
    [SerializeField] private Animator walkAnimator;

    private void Awake()
    {
        costumeAnimator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StealCostume(Costume newCostume)
    {
        Debug.Log($"{newCostume} was stolen!");
        costumeAnimator.SetInteger("CostumeIndex", (int)newCostume);
        walkAnimator.SetTrigger("NewCostume");
    }
}
