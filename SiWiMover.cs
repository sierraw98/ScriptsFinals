using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiWiMover : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb2d;

    void Update()
    {
        transform.Translate(Vector2.down * speed *Time.deltaTime, Space.World);
       
    }
}
