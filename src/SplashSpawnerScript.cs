using System;
using UnityEngine;

[Serializable]
public class SplashSpawnerScript : MonoBehaviour
{
	public GameObject BloodSplash;

	public Transform Yandere;

	public bool Bloody;

	public bool FootUp;

	public float Threshold;

	public virtual void Update()
	{
		if (!this.FootUp)
		{
			if (this.transform.position.y > this.Yandere.transform.position.y + 0.1f)
			{
				this.FootUp = true;
			}
		}
		else if (this.transform.position.y < this.Yandere.transform.position.y + this.Threshold)
		{
			this.FootUp = false;
			if (this.Bloody)
			{
				GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.BloodSplash, new Vector3(this.transform.position.x, this.Yandere.position.y, this.transform.position.z), Quaternion.identity);
				int num = -90;
				Vector3 eulerAngles = gameObject.transform.eulerAngles;
				float num2 = eulerAngles.x = (float)num;
				Vector3 vector = gameObject.transform.eulerAngles = eulerAngles;
				this.Bloody = false;
			}
		}
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.Bloody = true;
		}
	}

	public virtual void Main()
	{
	}
}
