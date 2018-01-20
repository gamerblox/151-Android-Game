using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //Obstacle prefab
    GameObject obstacle;

    //List of x pos of lanes
    public List<float> lanes;

    //Obstable spawn info
    public float minSpawnRate;
    public float maxSpawnRate;
    private bool canSpawn;

    //Slow start effect
    public bool slowStart = true;
    public float timeScaleStart;
    public float timeScaleLen;

	void Start ()
    {
        //loads prefab from resources
        obstacle = Resources.Load("Prefabs/Obstacle") as GameObject;

        //presets all vars
        canSpawn = true;
        Time.timeScale = timeScaleStart;

	}
	
	void Update ()
    {
        //if can spawn obstacle then spawn
		if (canSpawn)
        {
            StartCoroutine(SpawnCountdown());

        }

        //game start slow effect
        if (Time.timeScale < 1 && slowStart)
        {
            Time.timeScale += ((1 - timeScaleStart) / timeScaleLen) * Time.deltaTime;
            Debug.Log(Time.timeScale);
        }
        if (Time.timeScale >= 1)
        {
            slowStart = false;
            Time.timeScale = 1;
            Debug.Log(Time.timeScale);

        }

    }

    IEnumerator SpawnCountdown()
    {
        canSpawn = false;
        //Spawn an obstacle
        SpawnObstacle();
        //Wait for a random period of time
        yield return new WaitForSeconds(Random.Range(minSpawnRate, maxSpawnRate));
        canSpawn = true;

    }

    void SpawnObstacle()
    {
        //Randomly choose a lane to spawn in
        float xPos = lanes[Random.Range(0, lanes.Count)];
        //Gets player position
        Vector3 playerPos = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
        Vector3 spawnPos = new Vector3(xPos, playerPos.y + 12, 0);
        //Randomly instantiates an obstacle above player
        GameObject spawnedObstacle = Instantiate(obstacle, spawnPos, Quaternion.identity);
        Destroy(spawnedObstacle, 4f);

    }

}
