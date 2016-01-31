using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeleporterScript : MonoBehaviour {

    class Pair {
        public GameObject player;
        public float mtimer;

        public Pair(GameObject go, float in_timer)
        {
            player = go;
            mtimer = in_timer;
        }

        public void CountDownTimer(float dt)
        {
            mtimer -= dt;
        }

        public void SetTimer(float time)
        {
            mtimer = time;
        }

        public float GetTimer()
        {
            return mtimer;
        }
        public GameObject GetObject()
        {
            return player;
        }
    }

    public GameObject mExit;
    //public GameObject[] mWatchingPlayers;
    public float mMaxTimer;

    List<Pair> mPair = new List<Pair>();
    List<GameObject> mWatchingPlayers = new List<GameObject>();

	// Use this for initialization
	void Start () {

        mMaxTimer = 0.5f;


	}
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < mWatchingPlayers.Count;i++ )
        {
            if (Input.GetAxis("Vertical" + mWatchingPlayers[i].gameObject.GetComponent<Player>().joyNum) < 0)
            {
                mPair.Add(new Pair(mWatchingPlayers[i].gameObject, mMaxTimer));
                Vector2 tempPos = new Vector2(-100000.0f, -10000.0f);
                mWatchingPlayers[i].gameObject.transform.position = tempPos;
            }
        }


        for (int i = 0; i < mPair.Count; i++)
        {
            float tempTimer = Time.deltaTime;
            Debug.Log(tempTimer);
            mPair[i].CountDownTimer(tempTimer);
            Debug.Log(mPair[i].GetTimer());
            if (mPair[i].GetTimer() <= 0.0f)
            {
                mPair[i].GetObject().transform.position = mExit.gameObject.transform.position;
                mPair.RemoveAt(i);
                i--;
            }

        }
	}

     //void OnCollisionEnter2D (Collision2D collisionObject) {
     void OnTriggerEnter2D(Collider2D collisionObject) { 
        if (collisionObject.gameObject.tag == "Player")
        {
            mWatchingPlayers.Add(collisionObject.gameObject);
        }
     }

    void OnTriggerExit2D(Collider2D collisionObject)
    {
        if (collisionObject.gameObject.tag == "Player")
        {
            mWatchingPlayers.Remove(collisionObject.gameObject);
        }
    }

     
}
