using UnityEngine;
using System.Collections;

public class LaserProjectile : Projectile {

	LineRenderer lineRenderer;

	public float lifeTime = 1f;

	bool bounced = false;
	GameObject bounceObject = null;

	void Start () {
		lineRenderer = GetComponent<LineRenderer>();
	}

	void Update () {
		float castRadius = 0.5f;
		Vector2 castDir = new Vector2(speed.x, speed.y);
		Vector2 castStart = new Vector2(transform.position.x, transform.position.y) + (castDir * castRadius * 2);

		//RaycastHit2D rayHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), new Vector2(speed.x, speed.y), 500);
		RaycastHit2D rayHit = Physics2D.CircleCast(castStart, castRadius, castDir, 500);

		if (rayHit.transform) {
			lineRenderer.SetPosition(0, transform.position);
			lineRenderer.SetPosition(1, rayHit.point);


			if (!bounced) {
				//V-=2*Normal_wall*(Normal_wall.V) 
				// Vect1 - 2 * WallN * (WallN DOT Vect1)

				Vector2 reflect = speed - (2 * rayHit.normal) * (Vector2.Dot(rayHit.normal, speed));

				GameObject clone = GameObject.Instantiate(transform.gameObject);
				clone.transform.position = new Vector3(rayHit.point.x + rayHit.normal.x * 0.01f, rayHit.point.y + rayHit.normal.y * 0.01f, 0);
				clone.GetComponent<LaserProjectile>().speed = reflect; 
				clone.GetComponent<LaserProjectile>().bounceObject = rayHit.collider.gameObject;
				clone.GetComponent<LaserProjectile>().owner = owner;

				bounced = true;
			}
		}
		else {
			lineRenderer.SetPosition(0, transform.position);
			lineRenderer.SetPosition(1, transform.position + (new Vector3(speed.x, speed.y, 0) * 500));
		}

		if (lifeTime > 0)
			lifeTime -= Time.deltaTime;
		else
			GameObject.Destroy(transform.gameObject);
	}

}
/*
koda lite grann_här (*best of_kod){
	mycket (bös)
}

Haqvin 2010
*/