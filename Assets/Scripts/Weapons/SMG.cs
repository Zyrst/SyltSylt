using UnityEngine;
using System.Collections;

public class SMG : Weapon {

	public float delay = 0.05f;

	protected float shootTimer = 0;

	public int ammo = 20;

	void Start () {
		
	}
	
	protected override void UpdateInherit () {
		if (shootTimer > 0)
			shootTimer -= Time.deltaTime;
	}


	public override void holdFire() {
		if (shootTimer > 0)
			return;


		GameObject g = Instantiate(projectilePrototype);
		g.transform.position = transform.position;
		g.GetComponent<BulletScript>().speed = direction * 0.1f;
		g.GetComponent<Projectile>().owner = owner;
		g.GetComponent<BulletScript>().lifeTime = 5;

		shootTimer = delay;
		ammo--;
	}

	public override void releaseFire() {

	}

	public override int getAmmoLeft() {
		return ammo;
	}
}
