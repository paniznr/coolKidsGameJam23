using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public PlayerScript player;
    public TimerScript timer;
    public float deadZone = 30; // On the y-axis.
    public int timePenalty = 5;

    // Awake is called when the script instance is being loaded.
    private void Awake()
    {
        timer = GameObject.FindAnyObjectByType<TimerScript>();
        player = GameObject.FindAnyObjectByType<PlayerScript>();

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var currentDeadZone = player.getPosition().y + deadZone;
        if (transform.position.y > currentDeadZone)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        timer.subtractTime(timePenalty);
        // TODO: Add Music: MG
    }
}
