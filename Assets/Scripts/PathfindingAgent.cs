using UnityEngine;
using Pathfinding;

/// <summary>
/// A script to set an entity to follow a given target.
/// </summary>
public class PathfindingAgent : MonoBehaviour
{
    [SerializeField] private Transform target;

    private AIPath aiPath;
    private bool isFollowing = true;

    private void Awake()
    {
        aiPath = GetComponent<AIPath>();
    }

    private void Update()
    {
        if (isFollowing) { aiPath.destination = target.position; }
    }

    /// <summary>
    /// Set the agent to follow its target.
    /// Giving argument "true" will make the entity follow its target.
    /// Giving argument "false" will make the entity stop following its target.
    /// </summary>
    /// <param name="isFollowing">Whether or not the agent is currently following its targt/</param>
    public void SetFollowPlayer(bool isFollowing)
    {
        this.isFollowing = isFollowing;
        if (this.isFollowing) { aiPath.destination = target.position; }
        else { aiPath.destination = transform.position; } // New target is automatically reached
    }
}
