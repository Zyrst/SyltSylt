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
	        	GameObject.Destroy(weapon);
	        	weapon = null;
	        }
        }
	}

	public void setFlip(bool flip) {
		if (weapon != null)
			weapon.GetComponent<Weapon>().flip = flip;
	}
}
