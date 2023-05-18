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
    public AudioSource deathSound;
    public Animator animator;

    private float lastPosY;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {

        if (birdIsAlive)
        {

            // Set move the birds wings if it flies up
            if(transform.position.y < lastPosY)
            {
                animator.SetBool("isFlying", false);
            }
            lastPosY = transform.position.y;

            //Kill the bird if it flies out of screen:


            Vector3 objectPosition = transform.position;
            float objectHeight = GetComponent<Renderer>().bounds.size.y;
            float screenBottomY = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
            float screenTopY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;

            if (objectPosition.y + objectHeight < screenBottomY || objectPosition.y - objectHeight > screenTopY)
            {
                setDead();
            }



            // Input handler:
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            {
                flyBird();
            }

        }

    }

    void flyBird()
    {
        myRigidBody.velocity = Vector2.up * birdStrength;
        flapSound.Play();
        animator.SetBool("isFlying", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        setDead();
    }

    private void setDead()
    {
        if (!birdIsAlive)
        {
            //already dead...
            return;
        }
        
        animator.SetBool("isFlying", false);
        animator.SetBool("isDead", true);
        deathSound.Play();
        birdIsAlive = false;
        logic.gameOver();
    }
}
