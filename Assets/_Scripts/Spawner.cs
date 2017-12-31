using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour 
{
	[Header ("Enemy")]
	[SerializeField]
	GameObject m_EnemyPrefab1;

	[Header("Timer")]
	Timer m_SpawnerTimer = new Timer();
	[SerializeField]
	float SPAWNER_DURATION;

	void Update()
	{
		m_SpawnerTimer.Update(Time.deltaTime);
	}

	void OnTriggerStay2D(Collider2D myCol)
	{
		if (myCol.gameObject.tag == "PlayerBody" && m_SpawnerTimer.HasCompleted())
		{
			Instantiate(m_EnemyPrefab1, transform.localPosition, m_EnemyPrefab1.transform.rotation);
			m_SpawnerTimer.Set(SPAWNER_DURATION);
		}
	}
}