using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A singleton manager class for all InteractableObjects in a scene.
/// Manages interactions between the player and interactable objects.
/// </summary>
public class InteractableObjectManager : MonoBehaviour
{
    // Singleton instance
    public static InteractableObjectManager instance;

    [SerializeField] private Transform target;
    [SerializeField] private GameObject interactablePopup;

    private List<InteractableObject> interactableObjects;
    private InteractableObject activeObject; // The current active InteractableObject, null if none exist

    private void Awake()
    {
        instance = this;

        interactableObjects = new List<InteractableObject>();
    }

    /// <summary>
    /// Adds an InteractableObject to the list of InteractableObjects that this
    /// object must manage.
    /// </summary>
    /// <param name="io">The InteractableObject to add.</param>
    public void Subscribe(InteractableObject io)
    {
        interactableObjects.Add(io);
    }

    /// <summary>
    /// Request to make a pop up corresponding to the given InteractableObject
    /// pop up on screen.
    /// </summary>
    /// <param name="io">The InteractableObject requesting to be popped up.</param>
    public void RequestOpenPopup(InteractableObject io)
    {
        if (activeObject == null || (activeObject != io && CheckClosestInteractable(io)))
        {
            activeObject = io;
            // interactablePopup.SetActive(true);
        }
    }

    /// <summary>
    /// Request to close the current InteractableObject popup. Only works if
    /// the requesting popup is 
    /// </summary>
    /// <param name="io">The InteractableObject making the request.</param>
    public void RequestClosePopup(InteractableObject io)
    {
        if (activeObject && activeObject == io)
        {
            activeObject = null;
            // interactablePopup.SetActive(io);
        }
    }

    /// <summary>
    /// Request made by the given InteractableObject to execute its given task.
    /// </summary>
    /// <param name="io">The InteractableObject making the request.</param>
    public void RequestExecute(InteractableObject io)
    {
        if (activeObject && activeObject == io)
        {
            io.Execute();
        }
    }

    /// <summary>
    /// Checks if the given InteractableObject is closer to the target
    /// than the current active InteractableObject.
    /// </summary>
    /// <param name="io">The InteractableObject to compare.</param>
    /// <returns>True if the given InteractableObject is closer, false otherwise.</returns>
    private bool CheckClosestInteractable(InteractableObject io)
    {
        if (!activeObject) { return true; }

        float distanceToActiveObject = Vector3.Distance(target.position, activeObject.transform.position);
        float distanceToGivenObject = Vector3.Distance(target.position, io.transform.position);
        return distanceToGivenObject < distanceToActiveObject;
    }
}
