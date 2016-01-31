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
        GameObject player = Instantiate(player_);
        player.transform.position = transform.position - new Vector3(0, player.GetComponent<Collider2D>().bounds.size.y, 0);
    }
}
