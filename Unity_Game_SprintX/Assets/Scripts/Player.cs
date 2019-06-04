using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private Rigidbody2D myRigidbody;

	[SerializeField]
	private float movementSpeed;


    // Start is called before the first frame update
    void Start()
    {
       myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    	float horizontal = Input.GetAxis("Horizontal");
    	//Debug.log(horizontal);
        HandleMovement(horizontal);
    }

    private void HandleMovement(float Horizontal)
    {

    	myRigidbody.velocity = new Vector2(Horizontal * movementSpeed,myRigidbody.velocity.y);
    }
}
