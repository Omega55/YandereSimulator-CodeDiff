using System;
using UnityEngine;

public class GlobalKnifeArrayScript : MonoBehaviour
{
	public TimeStopKnifeScript[] Knives;

	public int ID;

	public void ActivateKnives()
	{
		foreach (TimeStopKnifeScript timeStopKnifeScript in this.Knives)
		{
			if (timeStopKnifeScript != null)
			{
				timeStopKnifeScript.Unfreeze = true;
			}
		}
		this.ID = 0;
	}
}
