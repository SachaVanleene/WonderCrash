using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 4.0f;

    private CharacterController _charCont;
    private Vector3 movment;
    Player stats;


    // Use this for initialization
    void Start() {
        stats = GetComponent<Player>();
    }


    void FixedUpdate()
    {
        float h = 0f;
        float v = 0f;
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        if (!stats.getSpotted())
        {
            Move(h, v);

        }

    }

    void Move(float h, float v)
    {
        movment.Set(h, 0f, v);
        movment = movment.normalized * speed * Time.deltaTime;
        transform.Translate(movment);
    }




}
