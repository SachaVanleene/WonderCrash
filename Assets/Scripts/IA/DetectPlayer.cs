using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour {


    IAGuard script_ia;
    public GameObject guard;
    bool playerChangedPersonallity;
    float timeToDetechChangement;
    public GameObject player;
    PlayerController script_player;



    private void Awake()
    {
        playerChangedPersonallity = false;
        timeToDetechChangement = 0.5f;
    }

    // Use this for initialization
    void Start () {
        script_ia = guard.GetComponent<IAGuard>();
        script_player = player.GetComponent<PlayerController>();
        script_player.addGuard(PersonallityChanged);
	}
	
    void PersonallityChanged()
    {
        StartCoroutine(PlayerChanged());
    }

    IEnumerator PlayerChanged()
    {
        if (!playerChangedPersonallity)
        {
            playerChangedPersonallity = true;
            yield return new  WaitForSeconds(timeToDetechChangement);
            playerChangedPersonallity = false;
        }
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
                if (hit.transform.tag == "Player" && (hit.transform.gameObject.GetComponent<PlayerController>().getCurrentCharacter() !=3) )
                {
                    Debug.LogError("Detecte");
                    script_ia.ChasePlayer(other.gameObject);
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            RaycastHit hit;
            if (Physics.Linecast(transform.position, other.gameObject.transform.position, out hit)) // ne pas détecter le joeur derrière un mur 
            {
                if (hit.transform.tag == "Player" && playerChangedPersonallity)
                {
                    Debug.LogError("Detecte Changement");
                    script_ia.ChasePlayer(other.gameObject);
                }
            }
        }
    }


}
