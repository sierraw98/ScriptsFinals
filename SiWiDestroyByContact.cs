using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SiWiDestroyByContact : MonoBehaviour {
    private AudioSource source;
    public AudioClip death;

     void Start()
    {
        source = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            source.PlayOneShot(death);
        }
        if (other.gameObject.CompareTag("PickUp"))
        {
            return;
        }
    }
    
}
