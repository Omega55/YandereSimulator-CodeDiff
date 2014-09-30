using System;
using UnityEngine;

[Serializable]
public class BloodPoolScript : MonoBehaviour
{
	public bool Bleed;

	public float Timer;

	public virtual void Start()
	{
		this.transform.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
	}

	public virtual void Update()
	{
		if (this.Bleed && this.Timer < (float)1)
		{
			this.Timer = Mathf.Lerp(this.Timer, (float)1, Time.deltaTime);
			this.transform.localScale = new Vector3(this.Timer, this.Timer, this.Timer);
		}
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.tag == "BloodSpawner")
		{
			this.Bleed = true;
		}
	}

	public virtual void OnTriggerExit(Collider other)
	{
		if (other.tag == "BloodSpawner")
		{
		}
	}

	public virtual void Main()
	{
	}
}
