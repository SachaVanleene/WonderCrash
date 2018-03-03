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


    public List<Interaction> GetDialogue(int niveau, int pnj, int personnalite) {

        string idDico = niveau.ToString() + "." + pnj.ToString() + "." + personnalite.ToString();
        Conv conv = Dialogues.GetConv(idDico);
        List<Interaction> qList = conv.interactionListe;
        
        return qList;
    }

    public void Start() {
        Time.timeScale = 1;
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

        Time.timeScale = 0;
        qList = m_qList;
        question.text = qCourante.interaction;
        reponsesQuestion = qCourante.reponseListe;

        int i = 0;
        if (reponsesQuestion != null)
        {

            foreach (Rep rep in reponsesQuestion)
            {
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
        panel.SetActive(false);
        Time.timeScale = 1;
    }

   
}
