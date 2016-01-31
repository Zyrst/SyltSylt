using UnityEngine;
using System.Collections;


public class LaserProjectile : Projectile {

	LineRenderer lineRenderer;

	public float lifeTime = 1f;

	bool bounced = false;
	public GameObject bounceObject = null;

	bool ded = false;

    public int bounce = 3; 

	void Start () {
		lineRenderer = GetComponent<LineRenderer>();
	}

	void Update () {
		float castRadius = 0.01f;
		Vector2 castDir = new Vector2(speed.x, speed.y);
		Vector2 castStart = new Vector2(transform.position.x, transform.position.y) + (castDir * (castRadius + 0.5f));

		//RaycastHit2D rayHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), new Vector2(speed.x, speed.y), 500);
		RaycastHit2D rayHit = Physics2D.CircleCast(castStart, castRadius, castDir, 500);

		Vector3 renderStart = transform.position;
		Vector3 renderEnd = transform.position + (new Vector3(speed.x, speed.y, 0) * 500);
		if (rayHit.transform)
			renderEnd = rayHit.point;

		lineRenderer.SetPosition(0, renderStart);
		lineRenderer.SetPosition(1, renderEnd);

        bool shake = false;

		if (rayHit.transform) {
			//lineRenderer.SetPosition(0, transform.position);
			//lineRenderer.SetPosition(1, rayHit.point);

			if (!ded) {
				if (rayHit.transform.tag.ToUpper().Equals("PLAYER") && rayHit.transform.gameObject != owner) {
					rayHit.transform.GetComponent<Player>().TakeDamage(owner);
					ded = true;
					shake = true;
				}
				else if (!bounced && bounce > 0) {
					//V-=2*Normal_wall*(Normal_wall.V) 
					// Vect1 - 2 * WallN * (WallN DOT Vect1)

					Vector2 reflect = speed - (2 * rayHit.normal) * (Vector2.Dot(rayHit.normal, speed));

					GameObject clone = GameObject.Instantiate(transform.gameObject);
					clone.transform.position = new Vector3(rayHit.point.x + rayHit.normal.x * 0.01f, rayHit.point.y + rayHit.normal.y * 0.01f, 0);
					clone.GetComponent<LaserProjectile>().speed = reflect; 
					clone.GetComponent<LaserProjectile>().bounceObject = rayHit.collider.gameObject;
					clone.GetComponent<LaserProjectile>().owner = owner;
                    bounce--;
                    clone.GetComponent<LaserProjectile>().bounce = bounce;
				}
			}
		}
		else {
			//lineRenderer.SetPosition(0, transform.position);
			//lineRenderer.SetPosition(1, transform.position + (new Vector3(speed.x, speed.y, 0) * 500));
		}

		if (lifeTime > 0)
			lifeTime -= Time.deltaTime;
		else
			GameObject.Destroy(transform.gameObject);

		bounced = true;

        if (shake)
            Camera.main.gameObject.GetComponent<CameraScript>().AddCameraShake(0.3f, 0.3f); 
	}

}
/*
koda lite grann_här (*best of_kod){
	mycket (bös)
}

Haqvin 2010
*/