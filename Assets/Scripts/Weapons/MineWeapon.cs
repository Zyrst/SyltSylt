using UnityEngine;
using System.Collections;

public class MineWeapon : Weapon {

	public float delay = 0.05f;
	float shootTimer = 0;

	public int ammo = 4;

	void Start () {
	}

	protected override void UpdateInherit() {
		float padd = 1.1f;
		transform.position += new Vector3(direction.x * padd, direction.y * padd, 0);

		shootTimer -= Time.deltaTime;
	}
	public override void holdFire() {
    }
	public override void releaseFire() {
		if (shootTimer > 0)
			return;

		GameObject g = Instantiate(projectilePrototype);
		g.transform.position = transform.position;
		g.GetComponent<Projectile>().speed = direction;
		g.GetComponent<Projectile>().owner = owner;

		AudioManager.instance.PlaySound(AudioManager.Tag.MinePlace);

		shootTimer = delay;
		ammo--;
    }

	public override int getAmmoLeft() {
		return ammo;
	}
}
