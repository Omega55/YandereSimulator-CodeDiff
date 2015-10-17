using System;
using UnityEngine;

[Serializable]
public class HomeYandereDetectorScript : MonoBehaviour
{
	public bool YandereDetected;

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = true;
		}
	}

	public virtual void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.YandereDetected = false;
		}
	}

	public virtual void Main()
	{
	}
}
