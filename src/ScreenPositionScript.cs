using System;
using UnityEngine;

[Serializable]
public class ScreenPositionScript : MonoBehaviour
{
	public virtual void Update()
	{
		this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3((float)0, (float)Screen.height, 1f));
	}

	public virtual void Main()
	{
	}
}
