using System;
using UnityEngine;

[Serializable]
public class AudioListenerScript : MonoBehaviour
{
	public Transform Target;

	public virtual void Update()
	{
		if (Camera.main != null)
		{
			this.transform.position = this.Target.position;
			this.transform.eulerAngles = Camera.main.transform.eulerAngles;
		}
	}

	public virtual void Main()
	{
	}
}
