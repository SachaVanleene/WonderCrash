using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

    
    public GameObject cam;
    [SerializeField] private Camera mapCamera;
    [SerializeField] private GameObject UI;

    private Camera mainCamera;

    // Use this for initialization
    void Start () {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        mainCamera = cam.GetComponent<Camera>();
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
            UI.SetActive(!UI.activeSelf);
        }
	}
}
