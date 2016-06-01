using System;
using UnityEngine;

[Serializable]
public class RooftopScript : MonoBehaviour
{
	public GameObject[] DumpPoints;

	public GameObject Railing;

	public GameObject Fence;

	public virtual void Start()
	{
		if (PlayerPrefs.GetInt("RoofFence") == 1)
		{
			for (int i = 0; i < this.DumpPoints.Length; i++)
			{
				this.DumpPoints[i].active = false;
			}
			this.Railing.active = false;
			this.Fence.active = true;
		}
	}

	public virtual void Main()
	{
	}
}
