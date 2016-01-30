using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public GameObject[] mPlayer;
    public float mMaxStrength, mTimer, mMaxTimer, mStrength;
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
	void Update ()
    {
        //ResetPos();
        BorderCheck();
        if (mTimer >= 0.0f)
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

    void BorderCheck()
    {
        //mMaxSize = GetComponent<Camera>().orthographicSize;
        //mMinSize = mMaxSize / 2.0f;
        //maxBorderWidth = 3.0f;


        //Find averagePos between all players.
        float averageX = 0.0f;
        float averageY = 0.0f;
        float maxX = -100.0f, minX = 100.0f, maxY = -100.0f, minY = 100.0f;

        //int i = 0;
        //GameObject tempObject = mPlayer[i];
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
        /*
        while (tempObject != null)
        {
            tempObject = mPlayer[i];
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

            i++;

        }*/

        //Confine average value
        /*if(averageY < -mMinSize)
        {
            averageY = -mMinSize;
        }else if(averageY > mMinSize)
        {
            averageY = mMinSize;
        }

        if(averageX < -mMinSize*(Screen.width/Screen.height))
        {
            averageX = -mMinSize * (Screen.width / Screen.height);
        }else if(averageX > mMinSize*(Screen.width/Screen.height))
        {
            averageX = mMinSize * (Screen.width / Screen.height);
        }*/

        /*float diffSize = maxY - minY;
        if((maxX - minX)*Screen.height/Screen.width > diffSize)
        {
            diffSize = (maxX - minX) * Screen.height / Screen.width;
        }

        if(diffSize > mMaxSize)
        {
            diffSize = mMaxSize;
        }

        else if(diffSize < mMinSize)
        {
            diffSize = mMinSize;
        }*/

        averageX = (maxX + minX) / 2.0f;
        averageY = (maxY + minY) / 2.0f;

        transform.position = new Vector3(averageX, averageY, transform.position.z);

        float dx = (maxX - minX) * Screen.height / Screen.width;
        float dy = maxY - minY;


        GetComponent<Camera>().orthographicSize = Mathf.Clamp(Mathf.Max(dx, dy),mMinSize, mMaxSize);
        
        /*
        mSize = mMaxSize;

        float maxBorderX = ;
        float maxBorderY;

        int i = 0;
        GameObject tempObject = mPlayer[i];
        while(tempObject != null)
        {
            Vector3 newPos = mPlayer[i].transform.position;
            i++;
            tempObject = mPlayer[i];
        }*/
    }
}
