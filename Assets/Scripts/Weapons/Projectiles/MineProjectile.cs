using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MineProjectile : Projectile {

	public GameObject theBay;

	Queue<GameObject> lastHitGameObject = new Queue<GameObject>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.transform.GetComponent<Player>() && collision.transform.gameObject != owner) {
			collision.transform.GetComponent<Player>().TakeDamage(owner);
			Instantiate(theBay).transform.position = transform.position;

			AudioManager.instance.PlaySound(AudioManager.Tag.Explosion);

			GameObject.Destroy(transform.gameObject);
		}
		else if (collision.transform.gameObject != owner) {
			if (!lastHitGameObject.Contains(collision.transform.gameObject))
				AudioManager.instance.PlaySound(AudioManager.Tag.GrenadeLand);
		}

		if (lastHitGameObject.Count > 5)
			lastHitGameObject.Dequeue();

		lastHitGameObject.Enqueue(collision.transform.gameObject);
	}
}
