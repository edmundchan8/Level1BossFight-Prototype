using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour 
{
	Vector3 m_Offset;
	float WIDTH_LIMIT = 70f;
	float HEIGHT_LIMIT = 83f;
	Camera m_Camera;

	float m_NormalView = 5f;
	float m_FarView = 7f;
	float m_OrthoViewSize;

	float ZOOM_DURATION = 2f;
	Timer m_ZoomTimer = new Timer();


	void Start()
	{
		m_Offset = transform.position - GameController.instance.ReturnPlayerPos();
		m_Camera = GetComponent<Camera>();
	}

	void Update()
	{
		transform.position = GameController.instance.ReturnPlayerPos() + m_Offset;
		//Clamp camera position so that the camera doesn't go beyond walls
		transform.position = new Vector3 (Mathf.Clamp(transform.position.x, -WIDTH_LIMIT, WIDTH_LIMIT), Mathf.Clamp(transform.position.y, -HEIGHT_LIMIT, HEIGHT_LIMIT), transform.position.z);

		m_ZoomTimer.Update(Time.deltaTime);
		if (!m_ZoomTimer.Update(Time.deltaTime))
		{
			m_Camera.orthographicSize = Mathf.Lerp(m_Camera.orthographicSize, m_OrthoViewSize, 0.2f);
			print(m_Camera.orthographicSize);
			print(m_OrthoViewSize);
		}

	}

	public void OnBossTile()
	{
		if (m_OrthoViewSize < m_FarView && m_ZoomTimer.Update(Time.deltaTime))
		{
			m_OrthoViewSize = m_FarView;
			m_ZoomTimer.Set(ZOOM_DURATION);
		}
	}

	public void NormalCameraView()
	{
		if (m_OrthoViewSize > m_NormalView)
		{
			m_OrthoViewSize = m_NormalView;
			m_ZoomTimer.Set(ZOOM_DURATION);
		}
	}

}
