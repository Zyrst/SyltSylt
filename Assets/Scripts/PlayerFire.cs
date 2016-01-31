using UnityEngine;
using System.Collections;

public class PlayerFire : MonoBehaviour {

	int joyNum;

	public GameObject weapon;
	
	// Use this for initialization
	void Start () {
		weapon = Instantiate(weapon);
        weapon.GetComponent<Weapon>().owner = transform.gameObject;
	}

	public void Init(int joyNum) {
		this.joyNum = joyNum;
	}
			
	// Update is called once per frame
	void Update () {
		if (weapon != null) {
			if (Input.GetButton("Fire" + joyNum)) {
	            weapon.GetComponent<Weapon>().holdFire();
	        }
			if (Input.GetButtonUp("Fire" + joyNum)) {
	            weapon.GetComponent<Weapon>().releaseFire();
	        }

	        weapon.transform.position = transform.position;
	        weapon.GetComponent<Weapon>().direction = transform.right;

	        if (weapon.GetComponent<Weapon>().getAmmoLeft() <= 0) {
	        	//GameObject.Destroy(weapon);
				//weapon.GetComponent<Rigidbody2D>().isKinematic = false;
				//weapon.GetComponent<Rigidbody2D>().AddForce((-transform.right + -transform.up) * 10, ForceMode2D.Impulse);
				//weapon.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-1000, 1000));
				//weapon.GetComponent<Collider2D>().enabled = true;
				GameObject.Destroy(weapon);
	        	weapon = null;
	        }
        }
	}

	public void setFlip(bool flip) {
		if (weapon != null)
			weapon.GetComponent<Weapon>().flip = flip;
	}

	public void changeWeapon(GameObject newWeapon) {
		if (weapon != null)
			GameObject.Destroy(weapon.gameObject);
		weapon = newWeapon;
        weapon.GetComponent<Weapon>().owner = transform.gameObject;
	}
}
