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
	[SerializeField]
	float PUSH_BACK_AMOUNT;
	Vector2 m_DirectionValue;

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

		if (m_Timer > MOVE_DURATION)
		{
			m_Timer = 0f;
		}
	}

	//TODO: this push back isn't work, when internet is back, have a think about how to push the enemy back
	public void EnemyPushBack()
	{
		Vector2 enemyPos = new Vector2(transform.position.x, transform.position.y);
		m_DirectionValue = (GameController.instance.GetPlayerPos() - enemyPos).normalized;
		transform.position = new Vector2(enemyPos.x + (PUSH_BACK_AMOUNT * -m_DirectionValue.x), (enemyPos.y + (PUSH_BACK_AMOUNT * -m_DirectionValue.y)));
	}
}
