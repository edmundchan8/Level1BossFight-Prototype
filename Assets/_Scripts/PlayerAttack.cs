using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour 
{
	[SerializeField]
	SpriteRenderer m_Attack;

	void Update()
	{
		if (Input.GetButtonDown("Attack"))
		{
			m_Attack.enabled = true;
		}
		else
		{
			m_Attack.enabled = false;
		}
	}

}
