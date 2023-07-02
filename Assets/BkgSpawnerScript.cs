using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BackgroundSpawnerScript : MonoBehaviour
{
    public GameObject player;
    RaycastHit2D spawnChecker;
    public float spawnCheckRadius = 5f;
    public Transform tilemap;
    public int spawnHeightOffset = 30;
    public float spawnRate = 2; // One spawn every 2 seconds
    public float offset = 10;
    private float timer = 0;

    public float leftEdge, rightEdge;

    public GameObject leftFence, rightFence;

    public GameObject[] collidables, nonCollidables;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var randomPicker = Random.Range(1, 11);
        var randomPickerNonCollidables = Random.Range(1, 11);
        // in the collidables array, the bear is always index 0, tree is index 1
        int nextObjIndex = 0;
        if (randomPicker > 3)
        {
            nextObjIndex = 1;
        }

        if (timer < spawnRate)
        {
            if(timer > 0.5 * spawnRate)
            {
                spawnFences();
            }
            timer += Time.deltaTime;
        }
        else
        {
            spawnFences();

            var nextObj = collidables[nextObjIndex];
            spawnObject(nextObj);
            if (randomPickerNonCollidables > 7)
            {
                spawnHouse();
            }
            timer = 0;
        }
        var currentSpawnPosition = player.transform.position.y - spawnHeightOffset;
        transform.position = new Vector3(
            transform.position.x,
            currentSpawnPosition,
            transform.position.z
        );
    }

    bool checkCollision(Vector2 objPosition)
    {
        // Create a function that checks if the obstacle is going to overlap another
        return Physics2D.CircleCast(
            new Vector2(objPosition.x, objPosition.y), spawnCheckRadius, new Vector2(0, 0)
            ).collider == null;
    }

    void spawnObject(GameObject prefab)
    {
        var obstaclePosition = new Vector3(
            Random.Range(leftEdge, rightEdge),
            transform.position.y,
            0
        );
        if (checkCollision(obstaclePosition))
        {
            Instantiate(prefab, obstaclePosition, transform.rotation, tilemap);
        }
    }

    void spawnHouse()
    {
        var randomHouse = nonCollidables[Random.Range(0,3)];
        spawnObject(randomHouse);
    }

    void spawnFences()
    {
        var leftFencePosition = new Vector3(
            leftEdge,
            transform.position.y,
            0
        );
        Instantiate(leftFence, leftFencePosition, transform.rotation, tilemap);
        var rightFencePosition = new Vector3(
            rightEdge,
            transform.position.y,
            0
        );
        Instantiate(rightFence, rightFencePosition, transform.rotation, tilemap);
    }
}
