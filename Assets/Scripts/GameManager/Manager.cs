using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

    public GameObject end_text;
    public GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SpottedEnd()
    {
        end_text.SetActive(true);
        Pause();
        StartCoroutine(waitBeforeGoToMenu());
    }

    IEnumerator waitBeforeGoToMenu()
    {
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    void Pause()
    {
        //Time.timeScale = 0;
        player.GetComponent<PlayerController>().talking = true;
        player.GetComponent<CameraFPS>().talking = true;
        DialogueManager.getChildGameObject(player, "Main Camera").GetComponent<CameraFPS>().talking = true;
    }
}
