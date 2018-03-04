using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfficheTuto : MonoBehaviour {

    public GameObject paneltuto;

	// Use this for initialization
	void Start () {
        paneltuto.SetActive(true);
	}
	
	
    public void closePanel()
    {
        paneltuto.SetActive(false);
    }
}
