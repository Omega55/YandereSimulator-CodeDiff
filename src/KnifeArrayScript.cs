using System;
using UnityEngine;

public class KnifeArrayScript : MonoBehaviour
{
	public GlobalKnifeArrayScript GlobalKnifeArray;

	public Transform KnifeTarget;

	public float[] SpawnTimes;

	public GameObject Knife;

	public float Timer;

	public int ID;

	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.ID < 10)
		{
			if (this.Timer > this.SpawnTimes[this.ID] && this.GlobalKnifeArray.ID < 1000)
			{
				GameObject gameObject = Object.Instantiate<GameObject>(this.Knife, base.transform.position, Quaternion.identity);
				gameObject.transform.parent = base.transform;
				gameObject.transform.localPosition = new Vector3(Random.Range(-1f, 1f), Random.Range(0.5f, 2f), Random.Range(-0.75f, -1.75f));
				gameObject.transform.parent = null;
				gameObject.transform.LookAt(this.KnifeTarget);
				this.GlobalKnifeArray.Knives[this.GlobalKnifeArray.ID] = gameObject.GetComponent<TimeStopKnifeScript>();
				this.GlobalKnifeArray.ID++;
				this.ID++;
				return;
			}
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}
}
