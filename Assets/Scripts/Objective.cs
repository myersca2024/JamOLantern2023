using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    [SerializeField] private Transform target;

    [Tooltip("If the target is at least this far away from this objective, then they will be notified")]
    [SerializeField] private int distanceAwayToNotify;

    [Header("Sprites")]
    [SerializeField] private GameObject objectiveArrow;
    [SerializeField] private GameObject objectiveMarker;

    private bool isActive = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            int screenWidth = Camera.main.scaledPixelWidth;
            int screenHeight = Camera.main.scaledPixelHeight;
            objectiveMarker.transform.position = Camera.main.WorldToScreenPoint(transform.position);
            objectiveMarker.SetActive(true);
            if (Vector3.Distance(transform.position, target.position) >= distanceAwayToNotify)
            {
                Debug.Log("GET OVER HERE!!!!");
                objectiveArrow.SetActive(true);

                Vector3 direction = transform.position -target.position;
                float ang = Vector3.Angle(direction, Vector3.right);
                Debug.Log($"DIRECTION VECTOR: {direction}");
                Debug.Log($"ANGLE to objective: {ang}");
                if (direction.z < 0)
                {
                    ang = 360 - ang;
                }
                objectiveArrow.transform.rotation = Quaternion.identity;
                objectiveArrow.transform.Rotate(new Vector3(0, 0, ang));

                float screenX;
                float screenY;
                if (ang >= 45 && ang < 135)
                {
                    screenX = ((135 - ang) / 90) * screenWidth;
                    screenY = 0;
                }
                else if (ang >= 135 && ang < 225)
                {
                    screenX = 0;
                    screenY = ((ang - 135) / 90) * screenHeight;
                }
                else if (ang >= 225 && ang < 315)
                {
                    screenX = ((ang - 225) / 90) * screenWidth;
                    screenY = screenHeight;
                }
                else
                {
                    ang += 360; // makes the math easier
                    screenX = screenWidth;
                    screenY = ((405 - ang) / 90) * screenHeight;
                }

                // Debug.Log($"ScreenX: {screenX} and ScreenY: {screenY}");
                // Debug.Log($"Screen to world point of 0,0: {Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 5))}");
                // Debug.Log($"Screen to world point of w,h: {Camera.main.ScreenToWorldPoint(new Vector3(screenWidth, screenHeight, 5))}");
                // Debug.Log($"Screen to world point of screenX, screenY: {Camera.main.ScreenToWorldPoint(new Vector3(screenX, screenY, 5))}");
                // objectiveArrow.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(screenX, screenY, 5));
                // objectiveArrow.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth, screenHeight, 5));
                // objectiveArrow.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 5));
                // objectiveArrow.transform.position = new Vector3(screenWidth / 2, screenHeight / 2);
            }
            else
            {
                objectiveArrow.SetActive(false);
            }
        }
        else
        {
            objectiveMarker.SetActive(false);
        }
    }

    public void ObjectiveAccomplished()
    {
        isActive = false;
    }
}
