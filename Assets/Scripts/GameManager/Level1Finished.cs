using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1Finished : MonoBehaviour {

    GameObject gameManager;
    public GameObject panel;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            panel.SetActive(true);
            panel.GetComponentInChildren<Text>().text = "Mission réussie : Vous vous êtes évadé !";
            gameManager.GetComponent<Manager>().GoToNextLevel(0);
        }
    }


    private void Awake() {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Use this for initialization
    void Start() {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update() {

    }
}
