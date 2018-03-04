using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionInfo : MonoBehaviour
{
    public GameObject panelInfo;

    private void Start()
    {
        //panelInfo = GameObject.FindGameObjectWithTag("InteractionPanel");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 12)
        {
            panelInfo.SetActive(true);
            panelInfo.GetComponentInChildren<Text>().text = "Appuyer sur E pour interagir";
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 12)
        {
            panelInfo.SetActive(false);
            panelInfo.GetComponentInChildren<Text>().text = "";
        }
    }
}
