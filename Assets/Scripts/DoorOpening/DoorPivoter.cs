using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPivoter : MonoBehaviour {


    public float speed = 2.0f;
    public float pivotAngle = 80f;

    public AudioClip door_open;
    public AudioClip door_close;
    public AudioClip door_locked;

    private bool isOpened = true;
    private bool isOpening = false;
    public bool isLocked = false;
    private float openAngle;
    private float closedAngle;
    private float currentAngle;
    private AudioSource source;
    private bool soundplaying;

    private void Start()
    {
        closedAngle = transform.eulerAngles.y;
        openAngle = transform.eulerAngles.y + pivotAngle;
        currentAngle = closedAngle;
        source = GetComponent<AudioSource>();
        soundplaying = false;
    }

    private void Update()
    {
        if (isOpening)
        {
            float targetAngle;
              if (!isOpened)
              {
                targetAngle = openAngle;
                if (!soundplaying)
                {
                    source.PlayOneShot(door_open);
                    soundplaying = true;
                }
                
              }
              else
              {
                targetAngle = closedAngle;
                if (!soundplaying)
                {
                    source.PlayOneShot(door_close);
                    soundplaying = true;
                }
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
        if (!isLocked){
            soundplaying = false;
            isOpened = !isOpened;
            isOpening = true;
        }  
    }

    public void Unlock()
    {
        isLocked = false;
    }

}
