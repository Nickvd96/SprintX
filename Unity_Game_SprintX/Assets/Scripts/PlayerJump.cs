using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

	private Rigidbody2D rigidbody2d;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
	{
		rigidbody2d = transform.GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
        	float jumpVelocity = 7f;
        	rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }
    }
}
