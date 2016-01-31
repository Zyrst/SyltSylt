using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnHandlerScript : MonoBehaviour {

    public GameObject player;

     List<GameObject> SpawnPoints;

	// Use this for initialization
	void Start () {
        Spawn(player);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddSpawnPoint(GameObject spawnPoint_)
    {
        SpawnPoints.Add(spawnPoint_);
    }

    public void Spawn(GameObject _player)
    {
        SpawnPoints[0].GetComponent<SpawnPointScript>().Spawn(_player);
    }
}
