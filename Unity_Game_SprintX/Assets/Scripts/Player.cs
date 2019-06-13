using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private Rigidbody2D myRigidbody;
	private Animator myAnimator;

	[SerializeField]
	private float movementSpeed;

	private bool FacingRight;

	[SerializeField]
	private Transform[] groundPoints;

	[SerializeField]
	private float groundRadius;

	[SerializeField]
	private LayerMask whatIsGround;

	private bool isGrounded;
	private bool Jump;

	[SerializeField]
	private float jumpForce;



    // Start is called before the first frame update
    void Start()
    {
       myRigidbody = GetComponent<Rigidbody2D>();
       FacingRight = true;
       myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()//50 times a second
    {


    	float horizontal = Input.GetAxis("Horizontal");
    	//Debug.log(horizontal);
		

        HandleMovement(horizontal);
        isGrounded = isGrounded();

        Flip(horizontal);
    }

    private void HandleMovement(float Horizontal)
    {

	
    	myRigidbody.velocity = new Vector2(Horizontal * movementSpeed,myRigidbody.velocity.y);

    	myAnimator.SetFloat("Speed", Mathf.Abs (Horizontal));

    	if(isGrounded && Jump == true)
    {
    	isGrounded = false;
    	myRigidbody.AddForce(new Vector2(0, jumpForce));
    }
    	
	}
	

	
    
    
    private void Flip(float Horizontal)
    {
    	if (Horizontal > 0 && !FacingRight || Horizontal <0 && FacingRight)
    	{
    		FacingRight = !FacingRight;

    		Vector3 theScale = transform.localScale;

    		theScale.x *= -1;

    		transform.localScale = theScale;
    	}
    }
    private bool isGrounded()
    {
    	if(myRigidbody.velocity.y <= 0)
    	{
    		foreach(Transform point in groundPoints)
    		
    		{
    			Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position,groundRadius, whatIsGround);

    			for (int i = 0; i< colliders.Lenght; i++)
    			{
    				if(colliders[i].gameObject != gameObject)
    				{
    					return true;
    				}
    			}

    		}
    	}
    	return false;
    }
    private void HandleInput()
    {
    	if(Input.GetKeyDown(KeyCode.Space))
    	{
    		jump = true;
    	}
    }
}


