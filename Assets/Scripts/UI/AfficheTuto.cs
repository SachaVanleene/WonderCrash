using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AfficheTuto : MonoBehaviour {

    public GameObject paneltuto;
    public Text tutoText;

    private GameObject player;
    private Scene currentScene;

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
        currentScene = SceneManager.GetActiveScene();

        if(currentScene.buildIndex == 1) {
            tutoText.text = "Bienvenue dans l’asile ' Mad Hatter ' \n\n Vous êtes sur le point d’incarner Ernest, patient aux multiples personnalités. Votre but : vous évader ! Mais ça ne sera pas tâche facile carles gardes sont à votre poursuite. \n\n Fort heureusement votre désordre mental sera la clé de votre évasion. Mais attention à ne pas en abuser, cela pourrait également causer votre perte... \n\n Commencer par prendre le carnet bleu pour découvrir votre personnalité.";
        }
        else if (currentScene.buildIndex == 2) {
            tutoText.text = "lvl1";
        }
        paneltuto.SetActive(true);
        Pause();
    }
	
	
    public void closePanel() {
        paneltuto.SetActive(false);
        Unpause();
    }


    void Pause() {
        Time.timeScale = 0;
        player.GetComponent<PlayerController>().talking = true;
        player.GetComponent<CameraFPS>().talking = true;
        DialogueManager.getChildGameObject(player, "Main Camera").GetComponent<CameraFPS>().talking = true;
    }


    void Unpause() {
        Time.timeScale = 1;
        player.GetComponent<PlayerController>().talking = false;
        player.GetComponent<CameraFPS>().talking = false;
        DialogueManager.getChildGameObject(player, "Main Camera").GetComponent<CameraFPS>().talking = false;
    }
}
