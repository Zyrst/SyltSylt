using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeleporterScript : MonoBehaviour {

    struct Pair {
        public GameObject player;
        public float timer;

        public Pair(GameObject go, float in_timer)
        {
            player = go;
            timer = in_timer;
        }

        public void CountDownTimer(float dt)
        {
            timer -= dt;
        }

        public float GetTimer()
        {
            return timer;
        }
        public GameObject GetObject()
        {
            return player;
        }
    }

    public GameObject mExit;
    public float mMaxTimer;

    List<Pair> mPair = new List<Pair>();

	// Use this for initialization
	void Start () {

        mMaxTimer = 0.5f;


	}
	
	// Update is called once per frame
	void Update () {
    
        for (int i = 0; i < mPair.Count; i++)
        {
            mPair[i].CountDownTimer(Time.deltaTime);
            if(mPair[i].GetTimer() <= 0.0f)
            {
                mPair[i].GetObject().transform.position = mExit.transform.position;
                mPair[i].GetObject().SetActive(true);
            }
            mPair.RemoveAt(i);
            i--;
        }
	}

     void OnCollisionEnter2D (Collision2D collisionObject) {
        if (collisionObject.gameObject.tag == "Player")
        {
            if(Input.GetAxis("Vertical" + collisionObject.gameObject.GetComponent<Player>().joyNum) < 0)
            {
                mPair.Add(new Pair(collisionObject.gameObject, mMaxTimer));
                collisionObject.gameObject.SetActive(false);
                Vector2 tempPos = new Vector2(-100000.0f, -10000.0f);
                collisionObject.gameObject.transform.position = tempPos;
            }
        }
     }
}
