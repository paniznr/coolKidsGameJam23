using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SnowSpawner : MonoBehaviour
{
    public float snowSpawnTimer = 8f;
    public float timer = 0f;
    public GameObject tilemap;
    public GameObject player;
    public int spawnHeightOffset = 30;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(tilemap, transform.position, transform.rotation, transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > snowSpawnTimer)
        {
            //Spawn
            Instantiate(tilemap, transform.position, transform.rotation, transform);
            timer = 0f;
        }
        else {
            timer += Time.deltaTime;
        }
        var currentSpawnPosition = player.transform.position.y - spawnHeightOffset;
        transform.position = new Vector3(
            transform.position.x,
            currentSpawnPosition,
            transform.position.z
        );
    }
    
}
