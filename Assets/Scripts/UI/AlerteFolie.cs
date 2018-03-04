using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlerteFolie : MonoBehaviour {

    public PlayerStats player;
    public Image icone;
    private bool isFlashing = false;

	// Use this for initialization
	void Start () {
        icone.gameObject.SetActive(false);
        player = player.GetComponent<PlayerStats>();
    }

    private void Update()
    {
        if (player.getCurrentChange() >= 75)
        {
            isFlashing = true;
            StartCoroutine(Blink());
        }
    }

    IEnumerator Blink()
    {
        while(isFlashing)
        {
            icone.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.7f);

            icone.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.7f);
        }
    }
}
