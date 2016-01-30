using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

  
    private int joyNum;
    private Rigidbody2D mBody;
    public float Speed;
    private bool mJumped = false;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        float sumX = 0;
        float sumY = 0;
        mJumped = false;
        if (Input.GetButton("Horizontal" + joyNum) && Input.GetAxisRaw("Horizontal" + joyNum) > 0)
        {
            sumX += 1;
        }
        if (Input.GetButton("Horizontal" + joyNum) && Input.GetAxisRaw("Horizontal" + joyNum) < 0)
        {
            sumX -= 1;
        }
        if(Input.GetButtonDown("Jump" + joyNum) && !mJumped)
        {
            mJumped = true;
        }
        sumX *= (Speed * Time.deltaTime);
        transform.position += new Vector3(sumX, sumY);
        if(mJumped)
        {
            mBody.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        }
        
	}

    public void Init(int playerNum, Rigidbody2D body)
    {
        joyNum = playerNum;
        mBody = body;
    }
}
