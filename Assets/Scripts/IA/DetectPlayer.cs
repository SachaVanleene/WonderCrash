using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour {


    IAGuard script_ia;
    public GameObject guard;



    // Use this for initialization
    void Start () {
        script_ia = guard.GetComponent<IAGuard>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //DetecPlayerPart

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            RaycastHit hit;
            if (Physics.Linecast(transform.position, other.gameObject.transform.position, out hit)) // ne pas détecter le joeur derrière un mur 
            {
                if (hit.transform.tag == "Player")
                {
                    Debug.LogError("Detecte");
                    script_ia.ChasePlayer(other.gameObject);
                }
            }
        }
    }
}
