using UnityEngine;
using System.Collections;

public class SpawnPointScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Game.Instance._spawnHandler.GetComponent<SpawnHandlerScript>().AddSpawnPoint(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Spawn(GameObject player_)
    {
        GameObject player = Instantiate(player_);
        player.transform.position = transform.position;
    }
}
