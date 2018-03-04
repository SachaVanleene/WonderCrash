using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepulsiveWall : MonoBehaviour {

    public Vector3 force;

    private Collider wallCollider;
    private PlayerController player;
    private float playerSpeed;

	// Use this for initialization
	void Start () {
        wallCollider = GetComponent<Collider>();
        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerController>();
        playerSpeed = player.speed;
	}

    private void OnTriggerStay(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.CompareTag("Player"))
        {
            if(force != null)
            {
                player.speed = 0;
                obj.GetComponent<Rigidbody>().AddForce(force);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.CompareTag("Player"))
        {
            //clear all forces
            obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
            obj.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            player.speed = playerSpeed;
        }
    }

}
