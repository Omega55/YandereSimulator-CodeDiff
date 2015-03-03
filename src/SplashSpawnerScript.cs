using System;
using UnityEngine;

[Serializable]
public class SplashSpawnerScript : MonoBehaviour
{
	public GameObject BloodSplash;

	public GameObject BloodPool;

	public Transform YandereChan;

	public bool Planted;

	public bool Bloody;

	public virtual void Update()
	{
		if (this.transform.position.y < 0.1f)
		{
			if (!this.Planted)
			{
				this.Planted = true;
				if (this.Bloody)
				{
					GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.BloodSplash, new Vector3(this.transform.position.x, this.YandereChan.position.y, this.transform.position.z), Quaternion.identity);
					int num = -90;
					Vector3 eulerAngles = gameObject.transform.eulerAngles;
					float num2 = eulerAngles.x = (float)num;
					Vector3 vector = gameObject.transform.eulerAngles = eulerAngles;
				}
			}
		}
		else
		{
			this.Planted = false;
		}
		if (this.BloodPool == null)
		{
			this.Bloody = false;
		}
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.BloodPool = other.gameObject;
			this.Bloody = true;
		}
	}

	public virtual void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.Bloody = false;
		}
	}

	public virtual void Main()
	{
	}
}
