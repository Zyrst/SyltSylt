using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    PlayerMovement move;
    PlayerFire fire;
    public int joyNum;

	// Use this for initialization
	void Start () {        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Create(int _joyNum)
    {
        joyNum = _joyNum;
        GetComponent<PlayerMovement>().Init(joyNum,GetComponent<Rigidbody2D>());
        GetComponent<PlayerFire>().Init(joyNum);
    }

    public void TakeDamage(GameObject killer)
    {
        GameObject.Find("DeathMatch").GetComponent<DeathMatch>().AddScore(killer.GetComponent<Player>().joyNum, 1);
    }

}
