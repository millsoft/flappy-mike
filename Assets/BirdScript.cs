using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{

    public Rigidbody2D myRigidBody;
    public float birdStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public AudioSource flapSound;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "Michael";
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {

        if (birdIsAlive && (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0))
        {
            myRigidBody.velocity = Vector2.up * birdStrength;
            flapSound.Play();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        birdIsAlive = false;
        logic.gameOver();
    }
}
