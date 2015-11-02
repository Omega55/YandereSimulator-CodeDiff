using System;
using UnityEngine;

[Serializable]
public class BloodPoolScript : MonoBehaviour
{
	public float TargetSize;

	public bool Blood;

	public bool Grow;

	public BloodPoolScript()
	{
		this.Blood = true;
	}

	public virtual void Start()
	{
		if (PlayerPrefs.GetInt("PantiesEquipped") == 7)
		{
			this.TargetSize *= 0.5f;
		}
		this.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
		if (this.transform.position.x > (float)50 || this.transform.position.x < (float)-50 || this.transform.position.z > (float)50 || this.transform.position.z < (float)-50)
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void Update()
	{
		if (this.Grow)
		{
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(this.TargetSize, this.TargetSize, this.TargetSize), Time.deltaTime * (float)1);
			if (this.transform.localScale.x > this.TargetSize * 0.99f)
			{
				this.Grow = false;
			}
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
