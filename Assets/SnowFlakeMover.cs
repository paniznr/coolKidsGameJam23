using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFlakeMover : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(0, (-6 + player.transform.position.y), 0);
        Debug.Log("snow pos " + transform.position);
        Debug.Log("player pos " + player.transform.position);
    }
}
