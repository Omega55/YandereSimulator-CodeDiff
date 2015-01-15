using System;
using UnityEngine;

[Serializable]
public class BloodPoolScript : MonoBehaviour
{
	public bool Grow;

	public virtual void Start()
	{
		this.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
	}

	public virtual void Update()
	{
		if (this.Grow)
		{
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)1);
		}
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodSpawner")
		{
			this.Grow = true;
		}
	}

	public virtual void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "BloodSpawner")
		{
		}
	}

	public virtual void Main()
	{
	}
}
