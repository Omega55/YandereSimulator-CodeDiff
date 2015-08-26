using System;
using UnityEngine;

[Serializable]
public class AudioListenerScript : MonoBehaviour
{
	public virtual void Update()
	{
		if (Camera.main != null)
		{
			this.transform.eulerAngles = Camera.main.transform.eulerAngles;
		}
	}

	public virtual void Main()
	{
	}
}
