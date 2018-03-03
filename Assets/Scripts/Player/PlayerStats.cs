using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    private bool spotted;
    public int maxPersonalityChange = 8;
    private float currentPersonalityChange;


    // Use this for initialization
    void Start () {
        spotted = false;
        currentPersonalityChange = 0;
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
