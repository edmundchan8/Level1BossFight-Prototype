using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashing : MonoBehaviour 
{
	//get the sprite renderer
	[SerializeField]
	SpriteRenderer m_SpriteRenderer;

	Timer m_FlashTimer = new Timer();
	Timer m_SpriteFlashTimer = new Timer();
	[SerializeField]
	float m_FlashDuration = 3f;
	float SpriteFlashDuration = 0.5f;
	[SerializeField]
	bool m_FlashChildren;

	bool m_IsFlashing;

	void Start()
	{
		m_SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}

	void FixedUpdate()
	{
		m_FlashTimer.Update(Time.deltaTime);
		m_SpriteFlashTimer.Update(Time.deltaTime);

		if(m_FlashTimer.Update(Time.deltaTime))
		{
			m_IsFlashing = false;
			m_SpriteRenderer.enabled = true;
			if (m_FlashChildren)
			{
				FlashRecursion(this.gameObject, true);
			}
		}

		else if (m_SpriteFlashTimer.Update(Time.deltaTime))
		{
			if (!GameController.instance.ReturnPlayerStats().PlayerDead())
			{
				m_SpriteRenderer.enabled = !m_SpriteRenderer.enabled;
				if (m_FlashChildren)
				{
					FlashRecursion(gameObject, m_SpriteRenderer.enabled);
				}
				m_SpriteFlashTimer.Set(SpriteFlashDuration);
			}
		}
		if (!m_FlashTimer.Update(Time.deltaTime))
		{
			m_IsFlashing = true;
		}
	}

	//turn it on
	public void StartFlashing()
	{
		m_FlashTimer.Set(m_FlashDuration);
	}

	//turn it off
	void FlashRecursion(GameObject obj, bool flash)
	{
		if (obj.GetComponent<SpriteRenderer>())
		{
			obj.GetComponent<SpriteRenderer>().enabled = flash;
		}
		foreach (Transform child in obj.transform)
		{
			FlashRecursion(child.gameObject, flash);
		}
	}

	public bool ReturnIsFlashing()
	{
		return m_IsFlashing;
	}
}
