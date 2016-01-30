using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour {

    public GameObject owner;
    public GameObject projectilePrototype;
	public Vector2 direction;

    public Weapon() {
    }

	void Start () {
	}
	
	void Update () {
	}

    public abstract void holdFire();
    public abstract void releaseFire();
}
