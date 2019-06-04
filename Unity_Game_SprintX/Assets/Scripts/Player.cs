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

        Flip(horizontal);
    }

    private void HandleMovement(float Horizontal)
    {

    	myRigidbody.velocity = new Vector2(Horizontal * movementSpeed,myRigidbody.velocity.y);

    	myAnimator.SetFloat("Speed", Mathf.Abs (Horizontal));
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
}
