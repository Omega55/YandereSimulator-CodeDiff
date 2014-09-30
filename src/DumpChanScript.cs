using System;
using UnityEngine;

[Serializable]
public class DumpChanScript : MonoBehaviour
{
	public float Timer;

	public virtual void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 1.417f)
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void Main()
	{
	}
}
