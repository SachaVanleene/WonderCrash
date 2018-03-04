using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text nomPnj, question;
    public List<Button> reponses;
    public Button endConv;
    public GameObject panel;

    private Interaction m_qCourante, m_qSuivante;
    private List<Interaction> qList;
    private List<Rep> reponsesQuestion;

    private GameObject player;


    public List<Interaction> GetDialogue(int niveau, int pnj, int personnalite) {
        string idDico = niveau.ToString() + "." + pnj.ToString() + "." + personnalite.ToString();
        Conv conv = Dialogues.GetConv(idDico);
        List<Interaction> qList = conv.interactionListe;
        
        return qList;
    }

    public void Start() {
        Time.timeScale = 1;
        player = GameObject.FindGameObjectWithTag("Player");
        //qList = GetDialogue(0, 2, 1);

        ////if(player.transform.position < certaineDistance && mouseClick && !hasSpokento)
        //// {

        //qCourante = qList[0];
        //question.text = qCourante.interaction;
        //reponsesQuestion = qCourante.reponseListe;

        //AfficheDialogue();
    }

    public void setButtonQuestion(string text)
    {
        question.text = text;
    }

    public void GetAnswerPressed(int idReponse)
    {
        int idQSuivante = reponsesQuestion[idReponse].interacSuiv;

        foreach (Interaction q in qList)
        {
            if (q.id == idQSuivante) m_qSuivante = q;
        }
        m_qCourante = m_qSuivante;

        AfficheDialogue(m_qCourante, qList);
    }

    public void AfficheDialogue(Interaction qCourante, List<Interaction> m_qList)
    {
        DisableCameraMovement();
        player.GetComponent<PlayerController>().talking = true;
        Time.timeScale = 0;
        qList = m_qList;
        question.text = qCourante.interaction;
        reponsesQuestion = qCourante.reponseListe;

        int i = 0;
        if (reponsesQuestion != null)
        {
            endConv.gameObject.SetActive(false);
            Debug.LogError("Y a des reponses");
            foreach (Rep rep in reponsesQuestion)
            {
                reponses[i].gameObject.SetActive(true);
                reponses[i].GetComponentInChildren<Text>().text = rep.reponse;
                i++;
            }
        } else
        {
            foreach (Button b in reponses)
            {
                b.gameObject.SetActive(false);
            }

            endConv.gameObject.SetActive(true);
        }

    }

    public void EndConversation()
    {
        EnableCameraMovement();
        player.GetComponent<PlayerController>().talking = false;
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    static public GameObject getChildGameObject(GameObject fromGameObject, string withName)
    {
        Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in ts) if (t.gameObject.name == withName) return t.gameObject;
        return null;
    }

    void DisableCameraMovement()
    {
        player.GetComponent<CameraFPS>().talking = true;
        getChildGameObject(player, "Main Camera").GetComponent<CameraFPS>().talking = true;
    }

    void EnableCameraMovement()
    {
        player.GetComponent<CameraFPS>().talking = false;
        getChildGameObject(player, "Main Camera").GetComponent<CameraFPS>().talking = false;
    }


}
