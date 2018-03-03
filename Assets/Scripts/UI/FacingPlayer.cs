using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingPlayer : MonoBehaviour {

    private GameObject cam;
    private Camera m_Camera;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        m_Camera = cam.GetComponent<Camera>();
    }

    void Update()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);
    }
}
