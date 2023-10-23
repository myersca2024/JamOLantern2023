using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generic interactable object class.
/// </summary>
public abstract class InteractableObject : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float interactRadius;

    private void Start()
    {
        // Sets target to the player by default
        if (target == null) { target = GameObject.FindGameObjectWithTag("Player").transform; }
    }

    private void Update()
    {
        
    }
}
