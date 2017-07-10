using System;
using UnityEngine;

public class HomeYandereDetectorScript : MonoBehaviour
{
	public bool YandereDetected;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag.Equals("Player"))
		{
			this.YandereDetected = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag.Equals("Player"))
		{
			this.YandereDetected = false;
		}
	}
}
