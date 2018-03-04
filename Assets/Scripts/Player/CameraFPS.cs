﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFPS : MonoBehaviour {

    public enum RotationAxis
    {
        MouseX = 1,
        MouseY = 2
    }

    public bool talking;

    public RotationAxis axes = RotationAxis.MouseX;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    public float sensHorizontal = 100.0f;
    public float sensVertical = 2.0f;

    public float _rotationX = 0;

    private void Awake()
    {
        minimumVert = -45.0f;
        maximumVert = 45.0f;

        sensHorizontal = 2.0f;
        sensVertical = 2.0f;

        _rotationX = 30f;

        talking = false;
}

    // Update is called once per frame
    void Update()
    {
        if (!talking)
        {
            if (axes == RotationAxis.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensHorizontal, 0);
            }
            else if (axes == RotationAxis.MouseY)
            {
                _rotationX -= Input.GetAxis("Mouse Y") * sensVertical;
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert); //Clamps the vertical angle within the min and max limits (45 degrees)

                float rotationY = transform.localEulerAngles.y;

                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            }
        }
    }
}

