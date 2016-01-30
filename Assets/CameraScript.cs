using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public GameObject[] mPlayer;
    public float mMaxStrength, mTimer, mMaxTimer, mStrength;
    public Vector3 origPos;

	// Use this for initialization
	void Start () {
	    mPlayer = new GameObject[1];
        CheckPlayers();
        origPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        ResetPos();
        if (mTimer >= 0.0f)
        {
            Shake();
            mTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown("space"))
        {
            AddCameraShake(0.3f, 0.3f);
        }
	}

    void CheckPlayers()
    {
        mPlayer = GameObject.FindGameObjectsWithTag("Player");
    }

    void AddCameraShake(float in_strength, float in_timer)
    {
        //Add if already shaking
        if (mTimer > 0.0f)
        {
            if (in_strength > mMaxStrength)
            {
                mMaxStrength = in_strength;
            }

            if(in_timer > mTimer)
            {
                mTimer = in_timer;
            }

            if(in_timer > mMaxTimer)
            {
                mMaxTimer = in_timer;
            }
        }

        //Set if not shaking
        else
        {
            mTimer = in_timer;
            mMaxTimer = in_timer;
            mMaxStrength = in_strength;
        }
    }

    void Shake()
    {
        Vector3 newPos = transform.position;
        mStrength = mMaxStrength * (mTimer / mMaxTimer);
        newPos.x += Random.Range(-mStrength, mStrength);
        newPos.y += Random.Range(-mStrength, mStrength);
        transform.position = newPos;
    }

    void ResetPos()
    {
        transform.position = origPos;
    }
}
