using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPerso : MonoBehaviour {

    public int id;
    public GameObject panel, canvas;

    private GameObject player;
    private PersonalityManager pm;
    private PlayerController pc;
    private int minDist = 10;


    // Use this for initialization
    void Start() {
        player = GameObject.FindWithTag("Player");
        pm = canvas.GetComponent<PersonalityManager>();
        pc = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update() {
        Vector3 distToPlayer = player.transform.position - gameObject.transform.position;

        if (distToPlayer.magnitude < minDist && Input.GetKeyDown(KeyCode.E)) {
            panel.SetActive(true);
            pm.FichePerso(id);
        }

        if (Input.GetKeyDown(KeyCode.Keypad1) && id == 1 || Input.GetKeyDown(KeyCode.Keypad2) && id == 2 || Input.GetKeyDown(KeyCode.Keypad3) && id == 3) {
            panel.SetActive(false);
            Destroy(gameObject);
        }
    }
}
