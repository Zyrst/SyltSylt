using UnityEngine;
using System.Collections;

public class SMG : Weapon {

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
		g.transform.position = transform.position;
		g.GetComponent<BulletScript>().speed = direction * 10 + new Vector2(Random.Range(-3, 3), Random.Range(-3, 3));
		g.GetComponent<Projectile>().owner = owner;

		shootTimer = delay;
	}

	public override void releaseFire() {

	}
}
