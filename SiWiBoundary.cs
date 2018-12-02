using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiWiBoundary : MonoBehaviour {

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
