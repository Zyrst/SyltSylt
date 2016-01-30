using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

  
    private int joyNum;
    private Rigidbody2D mBody;
    public float Speed;
    private bool mJumped = false;
    private float mDistToGround;
    bool faceLeft = true;
    bool pausedSprite = false;
    public bool grounded = true;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        float sumX = 0;
        //mJumped = false;
        if (Input.GetButton("Horizontal" + joyNum))
        {
            if(pausedSprite)
            {
                GetComponent<Animator>().enabled = true;
                pausedSprite = false;
            }
            sumX += Input.GetAxisRaw("Horizontal" + joyNum);
            float scale = Mathf.Clamp(sumX, -1, 1);
            if(faceLeft && sumX > 0)
            {
                faceLeft = false;
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
            else if(!faceLeft && sumX < 0)
            {
                faceLeft = true;
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
            
        }
        else if(!pausedSprite)
        {
            pausedSprite = true;
            GetComponent<Animator>().enabled = false;
        }
        if(Input.GetButtonDown("Jump" + joyNum) && grounded)
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

    
    public void OnTriggerEnter2D(Collider2D col)
    {
        grounded = true;
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        grounded = false;
    }
}
