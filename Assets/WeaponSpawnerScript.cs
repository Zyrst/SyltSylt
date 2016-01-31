using UnityEngine;
using System.Collections;

public class WeaponSpawnerScript : MonoBehaviour {

	public GameObject prefab;
	public int upperLimit = 500;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Random.Range(0, upperLimit) == 0) {
			GameObject g = Instantiate(prefab);
			g.transform.position = new Vector3(Random.Range(-45, 20), 17, 0);
		}
	}
}
