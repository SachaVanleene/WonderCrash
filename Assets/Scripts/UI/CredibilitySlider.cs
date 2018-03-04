using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CredibilitySlider : MonoBehaviour {

    [SerializeField] private GameObject player;

    private PlayerStats credibility;
    private UnityEngine.UI.Slider slider;

    // Use this for initialization
    void Start()
    {
        credibility = player.GetComponent<PlayerStats>();
        slider = GetComponent<UnityEngine.UI.Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = credibility.getCurrentSoupcon() / credibility.maxSoupconLevel;
    }
}
