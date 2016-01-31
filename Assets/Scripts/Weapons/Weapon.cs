using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour {

    public GameObject owner;
    public GameObject projectilePrototype;
	public Vector2 direction;
	public bool flip;

    public Weapon() {
    }

	void Start () {
	}
	
	void Update () {
		SpriteRenderer render = null;
		if ((render = GetComponent<SpriteRenderer>()) != null) {
			render.flipX = flip;
		}

		direction.x = flip ? -1 : 1;

		UpdateInherit();
	}

	protected abstract void UpdateInherit();
    public abstract void holdFire();
    public abstract void releaseFire();

    public abstract int getAmmoLeft();
}
