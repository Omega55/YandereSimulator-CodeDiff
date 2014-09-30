using System;
using UnityEngine;

[Serializable]
public class CaseDropAreaScript : MonoBehaviour
{
	public int Obstacles;

	public float Timer;

	public virtual void Update()
	{
		this.transform.localPosition = new Vector3((float)0, (float)0, -0.725f);
		this.Timer += Time.deltaTime;
		if (this.Timer > (float)1)
		{
			this.Obstacles = 0;
			this.Timer = (float)0;
		}
	}

	public virtual void OnTriggerStay(Collider other)
	{
		if (other.name != "GuitarCase" && other.name != "YandereChan" && other.name != "ShoeprintSpawner" && other.name != "BloodPool(Clone)" && other.name != "Floor")
		{
			this.Obstacles++;
		}
	}

	public virtual void Main()
	{
	}
}
