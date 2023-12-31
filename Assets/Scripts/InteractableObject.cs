using UnityEngine;

/// <summary>
/// Generic interactable object class.
/// </summary>
public abstract class InteractableObject : MonoBehaviour
{
    [Header("Interactable Object Settings")]
    [SerializeField] private Transform target;
    [SerializeField] private float interactRadius;
    [SerializeField] private string interactText;

    private bool targetEnteredRadius;

    private void Start()
    {
        // Sets target to the player by default
        if (target == null) { target = GameObject.FindGameObjectWithTag("Player").transform; }

        // Subscribe to the interactable object manager to manage interaction
        InteractableObjectManager.instance.Subscribe(this);
    }

    private void Update()
    {
        Debug.Log($"DISTANCE: {Vector3.Distance(transform.position, target.position)}");
        if (Vector3.Distance(transform.position, target.position) <= interactRadius)
        {
            InteractableObjectManager.instance.RequestOpenPopup(this);
            targetEnteredRadius = true;

            if (PlayerInput.instance.GetInteractPressed())
            {
                Debug.Log("SOMETHING IS INTERACTING");
                InteractableObjectManager.instance.RequestExecute(this);
            }
        }
        else if (targetEnteredRadius)
        {
            InteractableObjectManager.instance.RequestClosePopup(this);
            targetEnteredRadius = false;
        }
    }

    /// <summary>
    /// Executes the specified behavior of the InteractableObject that implements
    /// this class.
    /// </summary>
    public virtual void Execute() { }

    public float GetInteractionRadius()
    {
        return interactRadius;
    }
}
