using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawnerScript : MonoBehaviour
{

    public GameObject cloud;
    public float spawnRate = 4;
    private float spawnTimer = 0;
    public float cloudRange = 4;

    void Start()
    {
        spawnCloud();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer < spawnRate)
        {
            spawnTimer += Time.deltaTime;
        }
        else
        {
            spawnCloud();
            spawnTimer = 0;
        }
    }

    void spawnCloud()
    {
        //set spawn time for next cloud:
        spawnTimer = Random.Range(1, 3);

        float cloudHeightMin = transform.position.y - cloudRange;
        float cloudHeightMax = transform.position.y + cloudRange;

        GameObject newCloud = Instantiate(cloud, new Vector3(transform.position.x, Random.Range(cloudHeightMin, cloudHeightMax), 0), transform.rotation);

    }
}
