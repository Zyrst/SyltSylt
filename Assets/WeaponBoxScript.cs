using UnityEngine;
using System.Collections;

public class WeaponBoxScript : MonoBehaviour {

	public GameObject[] weaponsPrefabs;
	GameObject weapon;

	float lifeTimer = 10;

	// Use this for initialization
	void Start () {
		weapon = Instantiate(weaponsPrefabs[Random.Range(0, weaponsPrefabs.Length)]);
		weapon.GetComponent<SpriteRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		lifeTimer -= Time.deltaTime;
		if (lifeTimer < 0)
			GameObject.Destroy(transform.gameObject);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.transform.GetComponent<PlayerFire>()) {
			collision.transform.GetComponent<PlayerFire>().changeWeapon(weapon);
			weapon.GetComponent<SpriteRenderer>().enabled = true;
		
			GameObject.Destroy(transform.gameObject);
		}
	}
}
