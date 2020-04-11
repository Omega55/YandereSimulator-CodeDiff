using System;
using UnityEngine;

public class YanvaniaBlackHoleScript : MonoBehaviour
{
	public GameObject BlackHoleAttack;

	public int Attacks;

	public float SpawnTimer;

	public float Timer;

	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 1f)
		{
			this.SpawnTimer -= Time.deltaTime;
			if (this.SpawnTimer <= 0f && this.Attacks < 5)
			{
				Object.Instantiate<GameObject>(this.BlackHoleAttack, base.transform.position, Quaternion.identity);
				this.SpawnTimer = 0.5f;
				this.Attacks++;
			}
		}
	}
}
