using System;
using UnityEngine;

[Serializable]
public class RooftopScript : MonoBehaviour
{
	public GameObject DumpPoint;

	public GameObject Railing;

	public GameObject Fence;

	public virtual void Start()
	{
		if (PlayerPrefs.GetInt("Suicide") == 1)
		{
			this.DumpPoint.active = false;
			this.Railing.active = false;
			this.Fence.active = true;
		}
	}

	public virtual void Main()
	{
	}
}
