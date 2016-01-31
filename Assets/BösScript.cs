using UnityEngine;
using System.Collections;

public class BösScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Game.Instance._gameModes[0].GetComponent<DeathMatch>().Init(4, 2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
