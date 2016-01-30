using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    PlayerMovement move;
    PlayerFire fire;

	// Use this for initialization
	void Start () {
        move = GetComponent<PlayerMovement>();
        move.Init(1, GetComponent<Rigidbody2D>()); //Behövs annat sätt
        fire = GetComponent<PlayerFire>();
        fire.Init(1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
