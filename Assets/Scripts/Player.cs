using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    PlayerMovement move;
	// Use this for initialization
	void Start () {
        move = GetComponent<PlayerMovement>();
        move.Init(1, GetComponent<Rigidbody2D>());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
