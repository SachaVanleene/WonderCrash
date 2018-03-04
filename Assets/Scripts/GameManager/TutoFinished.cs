using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoFinished : MonoBehaviour {


    GameObject gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gameManager.GetComponent<Manager>().GoToNextLevel(0);
        }
    }


    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Use this for initialization
    void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
