using System;
using UnityEngine;

public class AccessoryGroupScript : MonoBehaviour
{
	public GameObject[] Parts;

	public void ActivateParts()
	{
		foreach (GameObject gameObject in this.Parts)
		{
			gameObject.SetActive(true);
		}
	}

	public void DeactivateParts()
	{
		foreach (GameObject gameObject in this.Parts)
		{
			gameObject.SetActive(false);
		}
	}
}
