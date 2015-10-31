using System;
using UnityEngine;

[Serializable]
public class YanvaniaBlackHoleScript : MonoBehaviour
{
	public GameObject BlackHoleAttack;

	public int Attacks;

	public float SpawnTimer;

	public float Timer;

	public virtual void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > (float)1)
		{
			this.SpawnTimer -= Time.deltaTime;
			if (this.SpawnTimer <= (float)0 && this.Attacks < 5)
			{
				UnityEngine.Object.Instantiate(this.BlackHoleAttack, this.transform.position, Quaternion.identity);
				this.SpawnTimer = 0.5f;
				this.Attacks++;
			}
		}
	}

	public virtual void Main()
	{
	}
}
