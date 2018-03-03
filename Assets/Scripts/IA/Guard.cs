using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour {



    public int suspicion;


    private void Awake()
    {
        suspicion = 0;
    }


    public void IncreaseSuspission(int s)
    {
        suspicion += s;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
