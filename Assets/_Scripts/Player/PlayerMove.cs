using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour 
{
	[SerializeField]
	float m_PlayerSpeed;
	[SerializeField]
	float KNOCK_BACK_AMOUNT;

	bool FACING_RIGHT = true;
	bool FACING_UP = false;

	Vector2 m_FacingDirection = Vector2.right;

	PlayerStats m_PlayerStats;

	[SerializeField]
	Animator m_PlayerAnimator;

	Rigidbody2D m_Rigidbody2D;

	void Start()
	{
		m_PlayerAnimator.SetBool("IsFacingRight", FACING_RIGHT);
		m_PlayerStats = GameController.instance.ReturnPlayerStats();
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () 
	{
		float movement = Input.GetAxis("Horizontal");
		m_PlayerAnimator.SetFloat("Movement", movement);
		m_Rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * m_PlayerSpeed, Input.GetAxis("Vertical") * m_PlayerSpeed);
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			float x = -1;
			transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
			m_FacingDirection = Vector2.left;
		}
		else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			float x = 1;
			transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
			m_FacingDirection = Vector2.right;
		}
		else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			m_FacingDirection = Vector2.up;
		}
		else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			m_FacingDirection = Vector2.down;
		}
	}

	void OnTriggerEnter2D(Collider2D myCol)
	{
		if (myCol.gameObject.tag == "Enemy" && !GameController.instance.ReturnPlayerAttackScript().PlayerAttacking() && !m_PlayerStats.ReturnInvulnerable())
		{
			Vector2 enemyPos = new Vector2(myCol.gameObject.transform.position.x, myCol.gameObject.transform.position.y);
			int enemyAttackDamage = myCol.gameObject.GetComponent<EnemyStats>().DealDamage();
			PlayerKnockBack(enemyAttackDamage, enemyPos);
			//TODO: This is where we start player flashing
			GameController.instance.ReturnPlayerFlashingScript().StartFlashing();
		}
	}

	public void PlayerKnockBack(int damage, Vector2 enemyPos)
	{
		Vector2 playerPos = new Vector2(transform.position.x, transform.position.y);
		Vector2 knockBackDirection = (enemyPos - playerPos).normalized;
		transform.position = new Vector2 (playerPos.x + (KNOCK_BACK_AMOUNT * -knockBackDirection.x), playerPos.y + (KNOCK_BACK_AMOUNT * knockBackDirection.y));
		m_PlayerStats.OnPlayerHit(damage);
	}

	public Vector2 ReturnFacingDirection()
	{
		return m_FacingDirection;
	}
}