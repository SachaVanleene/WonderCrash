using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPivoter : MonoBehaviour {

    public float speed = 1.0f;
    public float pivotAngle = 60f;

    private bool isOpened = false;
    private bool isOpening = false;
    private float openAngle;
    private float closedAngle;
    private float currentAngle;

    private void Start()
    {
        closedAngle = transform.eulerAngles.y;
        openAngle = transform.eulerAngles.y + pivotAngle;
        currentAngle = closedAngle;
    }

    private void Update()
    {
        if (isOpening)
        {
            float targetAngle;
              if (!isOpened)
              {
                targetAngle = openAngle;
              }
              else
              {
                targetAngle = closedAngle;
              }
            if (currentAngle == targetAngle)
            {
                isOpening = false;
            }
            else
            {
                currentAngle = Mathf.LerpAngle(currentAngle, targetAngle, Time.deltaTime * speed);

                transform.eulerAngles = new Vector3(transform.eulerAngles.x,
                                                    currentAngle,
                                                    transform.eulerAngles.z);
            }


        }

    }

    public void SwitchDoor()
    {
        isOpened = !isOpened;
        isOpening = true;
    }

}
