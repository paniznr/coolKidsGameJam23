using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = 50f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Without deltaTime, it's moving (moveSpeed) units per frame.
        // With deltaTime, -> units per second.
        transform.position = transform.position + (Vector3.up * moveSpeed) * Time.deltaTime;
        if (transform.position.y > deadZone)
        {
            if (transform.tag != "DoNotDelete") {
                Destroy(gameObject);
            }
        }
    }
}
