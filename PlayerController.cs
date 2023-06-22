using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[Header("Player Variables")]
	public float speed;
	public bool canMove = true;

	[Range(1, 30)]
	public float jumpVelocity;
	public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
	public bool grounded;

	private Rigidbody2D rb;

	private Animator m_anim;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		m_anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		//Player Horizontal Movement
		float moveHor = Input.GetAxis("Horizontal");
		Vector3 moveDir = new Vector3(moveHor * speed * Time.deltaTime, 0f);


		if (canMove)
		{
			transform.Translate(moveDir);
			//rb.velocity = new Vector2(moveHor * speed, rb.velocity.y);
			m_anim.SetFloat("Speed", Mathf.Abs(moveHor));
		}

		if (moveHor >= 0)
		{
			transform.localScale = new Vector3 (1f, 1f, 1f);
		}
		else if (moveHor < 0)
		{
			transform.localScale = new Vector3(-1f, 1f, 1f);
		}
	}

	private void Update()
	{
		if (Input.GetButtonDown("Jump") && grounded)
        {
			if (canMove)
            {
				rb.velocity = Vector2.up * jumpVelocity;
				grounded = false;
				m_anim.SetBool("Jumping", true);
                m_anim.SetBool("Grounded", false);
            }
            
        }

		//if Player is falling
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
			m_anim.SetBool("Falling", true);
			m_anim.SetBool("Jumping", false);
			m_anim.SetBool("Grounded", false);
        }

        //if Player is preforming a short jump
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Ground")
		{
			grounded = true;
			m_anim.SetBool("Grounded", true);
			m_anim.SetBool("Falling", false);
		}
		else
		{
			grounded = false;
		}

        if(col.gameObject.tag == "Hazzard")
		{
			
		}
	}

    public void EnableMove()
	{
		if(canMove)
		{
			canMove = false;
		}
		else
		{
			canMove = true;
		}
	}
}
