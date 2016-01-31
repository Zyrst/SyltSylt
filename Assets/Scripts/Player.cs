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
	    if(transform.position.y <= -150)
        {
            Game.Instance.GetComponent<SpawnHandlerScript>().Spawn(this.gameObject);
        }
	}

    public void Create(int _joyNum)
    {
        joyNum = _joyNum;
        GetComponent<PlayerMovement>().Init(joyNum,GetComponent<Rigidbody2D>());
        GetComponent<PlayerFire>().Init(joyNum);
    }

    public void TakeDamage(GameObject killer)
    {
		AudioManager.instance.PlaySound(AudioManager.Tag.TakeDamage);
        AudioManager.instance.PlaySound(AudioManager.Tag.Dies);
        Debug.Log(killer);
        GameObject go = GameObject.Find("DeathMatch(Clone)");
        if(go != null)
        {
            Debug.Log("Not null");
            go.GetComponent<DeathMatch>().AddScore(killer.GetComponent<Player>().joyNum, 1);
            Game.Instance.GetComponent<SpawnHandlerScript>().Spawn(this.gameObject);
        }

        //GameObject.Find("DeathMatch").GetComponent<DeathMatch>().AddScore(killer.GetComponent<Player>().joyNum, 1);
    }

}
