using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            int screenWidth = Camera.main.pixelWidth;
            int screenHeight = Camera.main.pixelHeight;
            float objectiveArrowWidth = objectiveArrow.GetComponent<Image>().sprite.bounds.size.x;
            float objectiveArrowHeight = objectiveArrow.GetComponent<Image>().sprite.bounds.size.y * 2;
            objectiveMarker.transform.position = Camera.main.WorldToScreenPoint(transform.position);
            objectiveMarker.SetActive(true);
            if (Vector3.Distance(transform.position, target.position) >= distanceAwayToNotify)
            {
                objectiveArrow.SetActive(true);

                Vector3 direction = transform.position - target.position;
                float ang = Vector3.Angle(direction, Vector3.right);
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
                    screenX = Mathf.Clamp(((135 - ang) / 90) * screenWidth, objectiveArrowWidth, screenWidth - objectiveArrowWidth);
                    screenY = screenHeight - objectiveArrowHeight;
                }
                else if (ang >= 135 && ang < 225)
                {
                    screenX = objectiveArrowWidth;
                    screenY = Mathf.Clamp(((225 - ang) / 90) * screenHeight, objectiveArrowHeight, screenHeight - objectiveArrowHeight);
                }
                else if (ang >= 225 && ang < 315)
                {
                    screenX = Mathf.Clamp(((ang - 225) / 90) * screenWidth, objectiveArrowWidth, screenWidth - objectiveArrowWidth);
                    screenY = objectiveArrowHeight;
                }
                else
                {
                    if (ang >= 0 && ang < 45)
                    {
                        ang += 360; // makes the math easier
                    }
                    screenX = screenWidth - objectiveArrowWidth;
                    screenY = Mathf.Clamp(((ang - 315) / 90) * screenHeight, objectiveArrowHeight, screenHeight - objectiveArrowHeight);
                }

                objectiveArrow.transform.position = new Vector3(screenX, screenY);
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
