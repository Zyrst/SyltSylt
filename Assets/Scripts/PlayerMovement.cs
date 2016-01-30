using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

  
    private int joyNum;
    private Rigidbody2D mBody;
    public float Speed;
    private bool mJumped = false;
    private float mDistToGround;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        float sumX = 0;
        //mJumped = false;
        if (Input.GetButton("Horizontal" + joyNum))
        {
            sumX += Input.GetAxisRaw("Horizontal" + joyNum);
        }
        if(Input.GetButtonDown("Jump" + joyNum) && OnGround())
        {
            mBody.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        }
        sumX *= (Speed * Time.deltaTime);
        transform.position += new Vector3(sumX, 0);
        
        
	}

    public void Init(int playerNum, Rigidbody2D body)
    {
        joyNum = playerNum;
        mBody = body;
        mDistToGround = GetComponent<Collider2D>().bounds.extents.y;
    }

    public bool OnGround()
    {
        Debug.DrawRay(transform.position - new Vector3(0, GetComponent<Collider2D>().bounds.extents.y), -Vector3.up - new Vector3(0, 0.1f, 0), Color.red, 10f);
        if (Physics2D.Raycast(transform.position - new Vector3(0, GetComponent<Collider2D>().bounds.extents.y), -Vector2.up, mDistToGround))
        {
            try
            {
                return true;
            }
            catch (System.NullReferenceException) { return false; }
        }
        else
        {
            return false;
        }
        
    }
}
