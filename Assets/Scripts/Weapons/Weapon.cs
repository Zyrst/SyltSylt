using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour {

    public GameObject tonky;
    public GameObject projectilePrototype;

    public Weapon() {
    }

	void Start () {
	}
	
	void Update () {
	}

    public abstract void holdFire();
    public abstract void releaseFire();
}
