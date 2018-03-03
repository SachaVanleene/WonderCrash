using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera mapCamera;

	// Use this for initialization
	void Start () {
        mainCamera.enabled = true;
        mapCamera.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        //Switch cameras if "c" key is down
        if (Input.GetKeyDown(KeyCode.C))
        {
            mainCamera.enabled = !mainCamera.enabled;
            mapCamera.enabled = !mapCamera.enabled;
        }
	}
}
