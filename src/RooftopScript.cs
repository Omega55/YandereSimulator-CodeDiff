using System;
using UnityEngine;

public class RooftopScript : MonoBehaviour
{
	public GameObject[] DumpPoints;

	public GameObject Railing;

	public GameObject Fence;

	private void Start()
	{
		if (PlayerPrefs.GetInt("RoofFence") == 1)
		{
			foreach (GameObject gameObject in this.DumpPoints)
			{
				gameObject.SetActive(false);
			}
			this.Railing.SetActive(false);
			this.Fence.SetActive(true);
		}
	}
}
