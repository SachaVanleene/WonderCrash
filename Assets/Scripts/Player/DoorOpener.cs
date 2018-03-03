using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Door"))
        {
            other.gameObject.transform.eulerAngles += new Vector3(0, 45, 0);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
