using System;
using UnityEngine;

public class AudioListenerScript : MonoBehaviour
{
	public Transform Target;

	private void Update()
	{
		Camera main = Camera.main;
		if (main != null)
		{
			base.transform.position = this.Target.position;
			base.transform.eulerAngles = main.transform.eulerAngles;
		}
	}
}
