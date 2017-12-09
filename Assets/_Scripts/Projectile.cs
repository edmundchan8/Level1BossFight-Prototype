using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour 
{
	[SerializeField]
	float m_Speed;
	[SerializeField]
	float m_Damage;

	[SerializeField]
	Vector2 m_Direction;
	[SerializeField]
	Vector2 m_CurrentPos;

	public void SetProjectileDirection(Vector2 currentPos, Vector2 endPos)
	{
		m_Direction = (endPos - currentPos).normalized;
	}

	void Update()
	{
		transform.Translate(m_Direction * m_Speed);
	}
}