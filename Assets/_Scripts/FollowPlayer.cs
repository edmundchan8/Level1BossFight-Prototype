using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour 
{
	Vector3 m_Offset;
	float WIDTH_LIMIT = 54f;
	float HEIGHT_LIMIT = 57f;

	void Start()
	{
		m_Offset = transform.position - GameController.instance.ReturnPlayerPos();
	}

	void Update()
	{
		transform.position = GameController.instance.ReturnPlayerPos() + m_Offset;
		//Clamp camera position so that the camera doesn't go beyond walls
		transform.position = new Vector3 (Mathf.Clamp(transform.position.x, -WIDTH_LIMIT, WIDTH_LIMIT), Mathf.Clamp(transform.position.y, -HEIGHT_LIMIT, HEIGHT_LIMIT), transform.position.z);
	}
}
