using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject Enemys;

    public GameObject AiMoveTargets;

    public float timeToStart = 1f;

    public float timeToRepeat = 5.0f;

    public float timeToEnd = 20.0f;

    public int EnemysSpawned = 0;


    public Transform[] SpawnPoints;

    private void Start()
    {
        InvokeRepeating("SpawnEnemies", timeToStart, timeToRepeat);
        timeToEnd = timeToEnd + timeToStart;

        if (timeToEnd > timeToRepeat)
        {
            Invoke("StopSpawn", timeToEnd);
        }
    }
    private void SpawnEnemies()
    {
        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            GameObject childObject = Instantiate(enemyPrefab, SpawnPoints[i].position, SpawnPoints[i].rotation) as GameObject;
            childObject.transform.parent = Enemys.transform;
            childObject.GetComponent<NavMesh>().AiMoveTargetsObject = AiMoveTargets.name;
            Enemys.SendMessage("RemoveEnemys");
            Enemys.SendMessage("AddEnemys");
            EnemysSpawned = EnemysSpawned + 1;
        }
        
    }

    private void StopSpawn()
    {
        CancelInvoke("SpawnEnemies");
        //this.gameObject.SetActive(false);
    }
}
