using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionPnj : MonoBehaviour
{

    public int id;
    private int minDistToTalk = 20;
    private GameObject player;
    private List<Interaction> qList;

    public GameObject panel, canvasDialogue, panelInfo;
    private Interaction qCourante, qSuivante;
    private List<Rep> reponsesQuestion;

    private DialogueManager dm;
    private PlayerController pc;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        dm = canvasDialogue.GetComponent<DialogueManager>();
        pc = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            panelInfo.SetActive(true);
            panelInfo.GetComponentInChildren<Text>().text = "appuyer sur E pour interagir";
        }

    }
    void OnTriggerStay()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Debug.LogError("interaction");
            panel.SetActive(true);
            int currentCharacter = pc.getCurrentCharacter();
            qList = dm.GetDialogue(0, id, currentCharacter);

            qCourante = qList[0];
            dm.setButtonQuestion(qCourante.interaction);
            reponsesQuestion = qCourante.reponseListe;
            dm.AfficheDialogue(qCourante, qList);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            panelInfo.SetActive(false);
            panelInfo.GetComponentInChildren<Text>().text = "";
        }
    }
}
