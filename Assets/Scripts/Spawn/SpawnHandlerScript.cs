using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnHandlerScript : MonoBehaviour {

     private List<GameObject> _spawnPoints = new List<GameObject>();

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddSpawnPoint(GameObject spawnPoint_)
    {
        _spawnPoints.Add(spawnPoint_);
    }

    public void Spawn(GameObject _player)
    {
        _spawnPoints[Random.Range(0, _spawnPoints.Count)].GetComponent<SpawnPointScript>().Spawn(_player);
    }
}
