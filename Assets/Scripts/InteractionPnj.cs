using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPnj : MonoBehaviour {

    public int id;
    private int minDistToTalk = 20;
    private GameObject player;
    private List<Interaction> qList;

    public GameObject panel, canvasDialogue;
    private Interaction qCourante, qSuivante;
    private List<Rep> reponsesQuestion;

    private DialogueManager dm;
    private PlayerController pc;

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
        dm = canvasDialogue.GetComponent<DialogueManager>();
        pc = player.GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 distToPlayer = player.transform.position - gameObject.transform.position;
        
        if (distToPlayer.magnitude < minDistToTalk && Input.GetKeyDown(KeyCode.E))
        { 
            panel.SetActive(true);
            int currentCharacter = pc.getCurrentCharacter();
            qList = dm.GetDialogue(0, id, currentCharacter);

            qCourante = qList[0];
            dm.setButtonQuestion(qCourante.interaction);
            reponsesQuestion = qCourante.reponseListe;

            dm.AfficheDialogue(qCourante, qList);
        }

    }
}
