using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float playerForce = 10f;
    public Rigidbody2D rigidbody;
    public float leftEdge, rightEdge;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rigidbody.velocity = Vector2.left * 5;
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            rigidbody.velocity = Vector2.right * 5;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Maybe slow down?
        }

        if (transform.position.x < leftEdge)
        {
            rigidbody.velocity = Vector2.right;
        }
        else if (transform.position.x > rightEdge)
        {
            rigidbody.velocity = Vector2.left;
        }

    }

    public Vector3 getPosition()
    { 
        return transform.position;
    }
}
