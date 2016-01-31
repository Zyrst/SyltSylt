using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public GameObject[] mPlayer;
    public float mMaxStrength = 1.0f, mTimer = 0.0f, mMaxTimer, mStrength;
    public Vector3 origPos;
    public float mMaxSize, mMinSize;
    public float maxBorderWidth;

	// Use this for initialization
	void Start () {
	    mPlayer = new GameObject[1];
        CheckPlayers();
        origPos = transform.position;
        mMaxSize = GetComponent<Camera>().orthographicSize;
        mMinSize = mMaxSize / 2.0f;
        maxBorderWidth = 3.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        GetComponent<ChromaticAberrationEffect>().intensity = 0;
        CheckPlayers();
        //ResetPos();
        BorderCheck();
        if (mTimer > 0.0f)
        {
            Shake();
            mTimer -= Time.deltaTime;
        }

        
	}

    void CheckPlayers()
    {
        mPlayer = GameObject.FindGameObjectsWithTag("Player");
    }

    /// <summary>
    /// Kameraskak. 0.3f och 0.3f är lagom
    /// 
    /// </summary>
    /// <param name="in_strength"> 0.3f är lagom</param>
    /// <param name="in_timer"> 0.3f är lagom</param>
    public void AddCameraShake(float in_strength, float in_timer)
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

        GetComponent<ChromaticAberrationEffect>().intensity = Mathf.Lerp(0f, 0.035f, mTimer / mMaxTimer); 
    }

    void ResetPos()
    {
        transform.position = origPos;
    }

    void BorderCheck()
    {
        float averageX = 0.0f;
        float averageY = 0.0f;
        float maxX = -100.0f, minX = 100.0f, maxY = -100.0f, minY = 100.0f;

        for (int i = 0; i < mPlayer.Length; i++)
        {
            Vector3 playerPos = mPlayer[i].transform.position;

            if (playerPos.x > maxX)
            {
                maxX = playerPos.x;
            } if (playerPos.x < minX)
            {
                minX = playerPos.x;
            } if (playerPos.y > maxY)
            {
                maxY = playerPos.y;
            } if (playerPos.y < minY)
            {
                minY = playerPos.y;
            }
        }

        //if(maxX > mMaxSize * (Screen.width/Screen.height))
        //{
        //    maxX = mMaxSize * (Screen.width / Screen.height);
        //}

        //if (maxX < -mMaxSize * (Screen.width / Screen.height))
        //{
        //    maxX = -mMaxSize * (Screen.width / Screen.height);
        //}

        //if (minX > mMaxSize * (Screen.width / Screen.height))
        //{
        //    minX = mMaxSize * (Screen.width / Screen.height);
        //}

        //if (minX < -mMaxSize * (Screen.width / Screen.height))
        //{
        //    minX = -mMaxSize * (Screen.width / Screen.height);
        //}

        //if(maxY > mMaxSize)
        //{
        //    maxY = mMaxSize;
        //}

        //if(maxY < -mMaxSize)
        //{
        //    maxY = -mMaxSize;
        //}

        //if(minY > mMaxSize)
        //{
        //    minY = mMaxSize;
        //}

        //if(minY < -mMaxSize)
        //{
        //    minY = -mMaxSize;
        //}



        averageX = (maxX + minX) / 2.0f;
        averageY = (maxY + minY) / 2.0f;

        float dx = (maxX - minX) * Screen.height / Screen.width;
        float dy = maxY - minY;

        //if (dx > mMaxSize * (Screen.width / Screen.height))
        //{
        //    dx = mMaxSize * (Screen.width / Screen.height);
        //}
        //if(dy > mMaxSize)
        //{
        //    dy = mMaxSize;
        //}

        //if (averageX + dx > mMaxSize * (Screen.width / Screen.height)/2)
        //{
        //    averageX = (mMaxSize * (Screen.width / Screen.height) / 2) - dx;
        //}

        //if (averageX - dx < -mMaxSize * (Screen.width / Screen.height) / 2)
        //{
        //    averageX = (-mMaxSize * (Screen.width / Screen.height) / 2) + dx;
        //}

        //if (averageY + dy > mMaxSize / 2)
        //{
        //    averageY = (mMaxSize / 2) - dy;
        //}

        //if (averageY - dy < -mMaxSize/2)
        //{
        //    averageY = (-mMaxSize /2)+ dy;
        //}


        transform.position = Vector3.Lerp(transform.position, new Vector3(averageX, averageY, transform.position.z), 0.1f);
        GetComponent<Camera>().orthographicSize = Mathf.Clamp(Mathf.Max(dx, dy),mMinSize, mMaxSize);
    }
}
