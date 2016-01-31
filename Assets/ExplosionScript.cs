using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

	public float timer = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0)
			GameObject.Destroy(transform.gameObject);
	
	}
}
