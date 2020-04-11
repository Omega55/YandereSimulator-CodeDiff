using System;
using UnityEngine;

public class RooftopScript : MonoBehaviour
{
	public GameObject[] DumpPoints;

	public GameObject Railing;

	public GameObject Fence;

	private void Start()
	{
		if (SchoolGlobals.RoofFence)
		{
			GameObject[] dumpPoints = this.DumpPoints;
			for (int i = 0; i < dumpPoints.Length; i++)
			{
				dumpPoints[i].SetActive(false);
			}
			this.Railing.SetActive(false);
			this.Fence.SetActive(true);
		}
	}
}
