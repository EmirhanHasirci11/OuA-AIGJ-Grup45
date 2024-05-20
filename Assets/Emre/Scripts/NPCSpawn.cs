using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawn : MonoBehaviour
{
    public GameObject[] npcPrefabs;
    public Transform[] spawnPoints;

    private float spawnInterval = 120f;
    private bool isColliding = false;
    private float spawnTimer;
    private GameObject currentNPC;

    void Update()
    {
        if (isColliding)
        {
            spawnTimer -= Time.deltaTime;

            if (spawnTimer <= 0f && currentNPC == null)
            {
                SpawnNPC();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = true;
            if (currentNPC != null)
            {
                Destroy(currentNPC);
            }
            spawnTimer = spawnInterval;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = false;
            spawnTimer = 0f;
        }
    }

    void SpawnNPC()
    {
        if (npcPrefabs.Length > 0 && spawnPoints.Length > 0)
        {
            int randomNPCIndex = Random.Range(0, npcPrefabs.Length);
            int randomSpawnIndex = Random.Range(0, spawnPoints.Length);

            currentNPC = Instantiate(npcPrefabs[randomNPCIndex], spawnPoints[randomSpawnIndex].position, spawnPoints[randomSpawnIndex].rotation);
        }
    }
}
