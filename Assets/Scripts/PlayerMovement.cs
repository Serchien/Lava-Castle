using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
	CharacterController2D controller;
	Rigidbody2D rb;
	Animator anim;

	float HorizontalMove = 0f;
	[SerializeField] float speed = 50f;
	bool jump = false;

	[SerializeField] Vector2 velocity;

	Vector2 lastPosition;

	private void Start()
	{
		controller = GetComponent<CharacterController2D>();
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();

		lastPosition = transform.position;
	}

	private void Update()
	{
		velocity = rb.velocity;

		HorizontalMove = Input.GetAxisRaw("Horizontal") * speed;

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			//anim.SetBool("Running", false);
			anim.SetBool("Jumping", true);
		}


		/*if(rb.velocity == new Vector2(0, 0))
		{
			anim.SetBool("Falling", false);
			anim.SetBool("Jumping", false);
			//anim.SetBool("Running", false);
		}*/

		if(rb.velocity.y < -0.5f)
		{
			anim.SetBool("Falling", true);
			anim.SetBool("Jumping", false);
			//anim.SetBool("Running", false);
		}
		else
		{
			anim.SetBool("Falling", false);

		}

		anim.SetFloat("Speed", Mathf.Abs(HorizontalMove));

		/*if (dist > 0.05f || dist < -0.05f)
		{
			anim.SetBool("Falling", false);
			anim.SetBool("Jumping", false);
			anim.SetBool("Running", true);
		}

		if (rb.velocity.x != 0 && rb.velocity.y == 0 && !jump)
		{

		}

		lastPosition = transform.position;
		*/
	}


	private void FixedUpdate()
	{
		controller.Move(HorizontalMove * Time.fixedDeltaTime, false, jump);
		jump = false;
	}


}
