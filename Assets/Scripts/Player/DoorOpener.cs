using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour {

    private DoorPivoter neighbourDoor = null;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Door"))
        {
            neighbourDoor = other.gameObject.GetComponent<DoorPivoter>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            neighbourDoor = null;
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(neighbourDoor != null)
            {
                neighbourDoor.SwitchDoor();
            }
        }
	}
}
