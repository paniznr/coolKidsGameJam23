using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour
{
    public LogicScript logic;
    public float deadZone = 30; // On the y-axis.

    // Awake is called when the script instance is being loaded.
    private void Awake()
    {
        logic = GameObject.FindAnyObjectByType<LogicScript>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > deadZone)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.layer == 3)
        //{
            logic.decreasePies(1);
        //}
    }
}
