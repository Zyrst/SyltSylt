using UnityEngine;
using System.Collections;

public class LaserWeapon : Weapon {

	public float delay = 0.05f;

	float shootTimer = 0;

	void Start () {
	}
	

	void Update () {
		if (shootTimer > 0)
			shootTimer -= Time.deltaTime;
	}


	public override void holdFire() {
		if (shootTimer > 0)
			return;

		GameObject g = Instantiate(projectilePrototype);
		g.transform.position = transform.position + (new Vector3(direction.x, direction.y, 0) * 2f);
		g.GetComponent<Projectile>().speed = direction;
		g.GetComponent<Projectile>().owner = owner;
		g.GetComponent<LaserProjectile>().bounceObject = owner;

		shootTimer = delay;
	}

	public override void releaseFire() {
		
	}
}
