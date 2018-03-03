using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    private bool spotted;
    private bool crazy;
    public float maxChange = 8;
    private float currentChange;


    // Use this for initialization
    void Start () {
        spotted = false;
        crazy = false;
        currentChange = 0;
    }
	

    public bool getSpotted()
    {
        return spotted;
    }

    public void setSpotted(bool spot)
    {
        spotted = spot;
    }

    public bool isCrazy()
    {
        return crazy;
    }

    public void incrCraziness(int incr)
    {
        if (!isCrazy()) currentChange += incr;
    }

    public float getCurrentChange()
    {
        return currentChange;
    }

	// Update is called once per frame
	void Update () {

        if (currentChange >= maxChange && !crazy)
        {
            crazy = true;
            PlayerController script = GetComponent<PlayerController>();
            StartCoroutine(script.RandomChange());
        }

	}
}
