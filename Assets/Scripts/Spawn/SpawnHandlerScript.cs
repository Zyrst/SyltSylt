using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnHandlerScript : MonoBehaviour {

     List<GameObject> SpawnPoints;

	// Use this for initialization
	void Start () {
	
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
        SpawnPoints[(int)Random.Range(0, SpawnPoints.Count)].GetComponent<SpawnPointScript>().Spawn(_player);
    }
}
