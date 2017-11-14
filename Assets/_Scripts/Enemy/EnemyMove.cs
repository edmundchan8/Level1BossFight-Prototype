using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour 
{
	[SerializeField]
	float m_EnemyMovement;
	float m_Timer = 0f;
	float CAN_MOVE_AMOUNT = 2f;
	float MOVE_DURATION = 4f;
	Vector2 m_MovingDirection;
	Rigidbody2D m_Rigidbody2D;

	void Start()
	{
		m_Rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		m_Timer += Time.deltaTime;
		if (m_Timer > CAN_MOVE_AMOUNT)
		{
			MoveTowardsPlayer();
		}
	}

	void MoveTowardsPlayer()
	{
		//transform.localPosition;
		//Always aim to make current pos = GameController.instance.GetPlayerPos
		// + / - x pos and + / - y pos
		Vector2 currentPos = new Vector2(transform.localPosition.x, transform.localPosition.y);
		Vector2 playerPos = GameController.instance.GetPlayerPos();

		if (currentPos.x < playerPos.x)
		{
			m_MovingDirection = Vector2.right;
			Vector2 newPos = transform.localPosition;
			newPos.x += m_EnemyMovement;
			transform.localPosition = newPos;
		}
		else
		{
			m_MovingDirection = Vector2.left;
			Vector2 newPos = transform.localPosition;
			newPos.x -= m_EnemyMovement;
			transform.localPosition = newPos;
		}

		if (currentPos.y < playerPos.y)
		{
			m_MovingDirection = Vector2.up;
			Vector2 newPos = transform.localPosition;
			newPos.y += m_EnemyMovement;
			transform.localPosition = newPos;
		}
		else
		{
			m_MovingDirection = Vector2.down;
			Vector2 newPos = transform.localPosition;
			newPos.y -= m_EnemyMovement;
			transform.localPosition = newPos;
		}

		if (m_Timer > MOVE_DURATION)
		{
			m_Timer = 0f;
		}
	}

	//TODO: this push back isn't work, when internet is back, have a think about how to push the enemy back
	public void EnemyPushBack()
	{
		m_Rigidbody2D.AddForce(-m_MovingDirection, ForceMode2D.Force);
	}
}
