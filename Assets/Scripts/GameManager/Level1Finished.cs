using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1Finished : MonoBehaviour {

    GameObject gameManager;
    public GameObject panel;
    GameObject player;

    public bool gg;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player" &&!gg) {
            panel.SetActive(true);
            gg = true;
            panel.GetComponentInChildren<Text>().text = "Mission réussie : Vous vous êtes évadé !";
            StartCoroutine(Gg());
        }
    }

    IEnumerator Gg()
    {
        Pause();
        yield return new WaitForSeconds(4);
        gameManager.GetComponent<Manager>().GoToNextLevel(0);
    }


    private void Awake() {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gg = false;
    }

    // Use this for initialization
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    void Pause()
    {
        player.GetComponent<PlayerController>().talking = true;
        player.GetComponent<CameraFPS>().talking = true;
        DialogueManager.getChildGameObject(player, "Main Camera").GetComponent<CameraFPS>().talking = true;
    }

    // Update is called once per frame
    void Update() {

    }
}
