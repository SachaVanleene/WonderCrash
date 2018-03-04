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
    bool active;
    InteractionInfo script_info;


    // Use this for initialization
    void Start() {
        player = GameObject.FindWithTag("Player");
        pm = canvas.GetComponent<PersonalityManager>();
        pc = player.GetComponent<PlayerController>();
        script_info = GetComponent<InteractionInfo>();
        active = false;
    }

    // Update is called once per frame
    void Update() {
        Vector3 distToPlayer = player.transform.position - gameObject.transform.position;

        if (distToPlayer.magnitude < minDist && Input.GetKeyDown(KeyCode.E)) {
            Pause();
            panel.SetActive(true);
            pm.FichePerso(id);
            active = true;
        }

        if ((Input.GetKeyDown(KeyCode.Alpha1) && id == 1 || Input.GetKeyDown(KeyCode.Alpha2) && id == 2 || Input.GetKeyDown(KeyCode.Alpha3) && id == 3) && active) {
            script_info.panelInfo.SetActive(false);
            Unpause();
            panel.SetActive(false);
            Destroy(gameObject);
        }
    }

    void Pause()
    {
        Time.timeScale = 0;
        player.GetComponent<PlayerController>().talking = true;
        player.GetComponent<CameraFPS>().talking = true;
        DialogueManager.getChildGameObject(player, "Main Camera").GetComponent<CameraFPS>().talking = true;
    }

    void Unpause()
    {
        Time.timeScale = 1;
        player.GetComponent<PlayerController>().talking = false;
        player.GetComponent<CameraFPS>().talking = false;
        DialogueManager.getChildGameObject(player, "Main Camera").GetComponent<CameraFPS>().talking = false;
    }
}
