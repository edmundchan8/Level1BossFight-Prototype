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
	float SPAWNER_DURATION = 3f;

	void Update()
	{
		m_SpawnerTimer.Update(Time.deltaTime);
	}

	void OnTriggerStay2D(Collider2D myCol)
	{
		if (myCol.gameObject.tag == "Player" && m_SpawnerTimer.HasCompleted())
		{
			Instantiate(m_EnemyPrefab1, transform.localPosition, m_EnemyPrefab1.transform.rotation);
			m_SpawnerTimer.Set(SPAWNER_DURATION);
		}
	}
}