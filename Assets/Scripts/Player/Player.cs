using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private bool spotted;



	// Use this for initialization
	void Start () {
        spotted = false;
	}
	

    public bool getSpotted()
    {
        return spotted;
    }

    public void setSpotted(bool spot)
    {
        spotted = spot;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
