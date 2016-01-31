using UnityEngine;
using System.Collections;

public class LaserWeapon : Weapon {

	public float delay = 0.05f;
	float shootTimer = 0;

	public int ammo = 10;

	void Start () {
	}
	

	protected override void UpdateInherit () {
		if (shootTimer > 0)
			shootTimer -= Time.deltaTime;

		transform.position += new Vector3(0, -0.4f, 0) + new Vector3(direction.x, direction.y, 0) * 0.4f;
	}


	public override void holdFire() {
		if (shootTimer > 0)
			return;

		GameObject g = Instantiate(projectilePrototype);
		g.transform.position = transform.position + (new Vector3(direction.x, direction.y, 0) * 2f);
		g.GetComponent<Projectile>().speed = direction;
		g.GetComponent<Projectile>().owner = owner;
		g.GetComponent<LaserProjectile>().bounceObject = owner;

		AudioManager.instance.PlaySound(AudioManager.Tag.LazerShot);

		shootTimer = delay;
		ammo--;
	}

	public override void releaseFire() {
		
	}

	public override int getAmmoLeft() {
		return ammo;
	}
}
