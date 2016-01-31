using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

  
    private int joyNum;
    private Rigidbody2D mBody;
    public float Speed;
    private bool mJumped = false;
    public bool faceLeft = true;
    public bool grounded = true;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        float sumX = 0;
        //mJumped = false;
        if (Input.GetButton("Horizontal" + joyNum) || Input.GetAxis("Horizontal" + joyNum) < 0 || Input.GetAxis("Horizontal" + joyNum) > 0)
        {
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

            //If forces are applied nullify if we try walking other way
            if(sumX > 0 && mBody.velocity.x < 0)
            {
                mBody.velocity = new Vector2(0, mBody.velocity.y);
            }
            else if (sumX < 0 && mBody.velocity.x > 0)
            {
                mBody.velocity = new Vector2(0, mBody.velocity.y);
            }
        }
       
        if(Input.GetButtonDown("Jump" + joyNum) && grounded)
        {
            mBody.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            GetComponent<Animator>().SetTrigger("Jump");

            AudioManager.instance.PlaySound(AudioManager.Tag.Jump);
        }
        sumX *= (Speed * Time.deltaTime);
        transform.position += new Vector3(sumX, 0);
        
	}

    public void Init(int playerNum, Rigidbody2D body)
    {
        joyNum = playerNum;
        mBody = body;
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
