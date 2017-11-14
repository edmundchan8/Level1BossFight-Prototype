using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour 
{
	[SerializeField]
	float m_EnemyMovement;
	float m_Timer = 0f;
	float MOVE_DURATION = 2f;


	void FixedUpdate()
	{
		m_Timer += Time.deltaTime;
		if (m_Timer > MOVE_DURATION)
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
			Vector2 newPos = transform.localPosition;
			newPos.x += m_EnemyMovement;
			transform.localPosition = newPos;
		}
		else
		{
			Vector2 newPos = transform.localPosition;
			newPos.x -= m_EnemyMovement;
			transform.localPosition = newPos;
		}

		if (currentPos.y < playerPos.y)
		{
			Vector2 newPos = transform.localPosition;
			newPos.y += m_EnemyMovement;
			transform.localPosition = newPos;
		}
		else
		{
			Vector2 newPos = transform.localPosition;
			newPos.y -= m_EnemyMovement;
			transform.localPosition = newPos;
		}

		if (m_Timer > 4f)
		{
			m_Timer = 0f;
		}
	}
}
