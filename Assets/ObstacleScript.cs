using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    private LogicScript logic;
    private PlayerScript player;

    [SerializeField] float deadZone = 30; // On the y-axis.
    [SerializeField] int timePenalty = 5;

    // Awake is called when the script instance is being loaded.
    private void Awake()
    {
        logic = GameObject.FindAnyObjectByType<LogicScript>();
        player = GameObject.FindAnyObjectByType<PlayerScript>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!logic.IsGameStarted || logic.IsGameOver)
        {
            return;
        }
        var currentDeadZone = player.getPosition().y + deadZone;
        if (transform.position.y > currentDeadZone)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.subtractTime(timePenalty);
        // TODO: Add Music: MG
    }
}
