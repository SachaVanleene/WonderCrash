using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentalSlider : MonoBehaviour
{

    [SerializeField] private GameObject player;

    private PlayerStats mentalHealth;
    private UnityEngine.UI.Slider slider;

    // Use this for initialization
    void Start()
    {
        mentalHealth = player.GetComponent<PlayerStats>();
        slider = GetComponent<UnityEngine.UI.Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = mentalHealth.getCurrentChange() / mentalHealth.maxChange;
    }
}
