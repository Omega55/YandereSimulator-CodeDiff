using System;
using UnityEngine;

public class ListScript : MonoBehaviour
{
	public Transform[] List;

	public bool AutoFill;

	public void Start()
	{
		if (this.AutoFill)
		{
			for (int i = 1; i < this.List.Length; i++)
			{
				this.List[i] = base.transform.GetChild(i - 1);
			}
		}
	}
}
