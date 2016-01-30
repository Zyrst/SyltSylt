using UnityEngine;
using System.Collections;

public class SpawnPointScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Spawn(GameObject _player)
    {
        GameObject player = Instantiate(_player);
        player.transform.position = transform.position;
    }
}
