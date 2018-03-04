using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    private bool spotted;
    private bool crazy;
    public float maxChange;
    private float currentChange;
    public float maxSoupconLevel;
    private float currentSoupcon;

    GameObject gameManager;



    // Use this for initialization
    void Start () {
        spotted = false;
        crazy = false;
        currentChange = 0;
        currentSoupcon = 0;

        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }
	

    public bool getSpotted()
    {
        return spotted;
    }

    public void setSpotted(bool spot)
    {
        spotted = spot;
        if (spotted)
        {
            gameManager.GetComponent<Manager>().SpottedEnd();
        }
    }

    public bool isCrazy()
    {
        return crazy;
    }

    public void incrCraziness(float incr)
    {
        if (!isCrazy()) currentChange += incr;
    }

    public void incrSoupcon(float incr)
    {
        if (!spotted) currentSoupcon += incr;
    }


    public float getCurrentChange()
    {
        return currentChange;
    }

    public float getCurrentSoupcon()
    {
        return currentSoupcon;
    }

	// Update is called once per frame
	void Update () {

        if (currentChange >= maxChange && !crazy)
        {
            crazy = true;
            PlayerController script = GetComponent<PlayerController>();
            StartCoroutine(script.RandomChange());
        }
        if(currentSoupcon >= maxSoupconLevel && !spotted)
        {
            spotted = true;
        }

	}
}
