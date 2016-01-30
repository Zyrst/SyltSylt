using UnityEngine;
using System.Collections;

public class BulletScript : Projectile {

	public float lifeTime = 1;

	void Start () {
	}
	
	void Update () {
		transform.position += new Vector3(speed.x, speed.y, 0);

		if (lifeTime > 0)
			lifeTime -= Time.deltaTime;
		else
			GameObject.Destroy(transform.gameObject);
	}


	void OnCollisionEnter2D(Collision2D collision) {
		// Ignore projectiles
		if (collision.transform.GetComponent<Projectile>())
			return;

		GameObject.Destroy(transform.gameObject);
	}
}
