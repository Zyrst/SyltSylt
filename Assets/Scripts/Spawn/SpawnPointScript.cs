using UnityEngine;
using System.Collections;

public class SpawnPointScript : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        Game.Instance.GetComponent<SpawnHandlerScript>().AddSpawnPoint(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Spawn(GameObject player_)
    {
        player_.transform.position = transform.position + new Vector3(0, player_.GetComponent<Renderer>().bounds.size.y, 0);
    }
}
