using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{

    public float moveSpeed = 5;
    public float pipeDeadZone = -45;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < pipeDeadZone)
        {
            //delete pipes
            Debug.Log("Pipe deleted");
            Destroy(gameObject);
        }
    }
}
