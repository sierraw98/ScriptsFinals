using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class SiWiPlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    public Boundary boundary;
    public Text scoreText;
    public Text WinText;
    private int score;

    public AudioClip pollen;
    private AudioSource source;
    private float volLowRange = 0.5f;
    private float volHighRange = 1.0f;
   
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        SetScore ();
       source = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);

        rb2d.position = new Vector2
       (
            Mathf.Clamp(rb2d.position.x, boundary.xMin, boundary.xMax),

            Mathf.Clamp(rb2d.position.y, boundary.yMin, boundary.yMax)
       );
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            score = score + 2;
            SetScore();
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(pollen);

        }
        if (other.tag == "Boundary")
        {
            return;
        }
    }

    void SetScore ()
    {
        scoreText.text = "Score: " + score.ToString ();
        if (score ==10)
        {
            WinText.text = "YOU SAVED THE BEES!!";
        }
    }

}
